using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using Color = System.Drawing.Color;
using Region = devDept.Eyeshot.Entities.Region;
using Timer = System.Windows.Forms.Timer;

namespace Stack
{
    public partial class Form1 : Form
    {
        private Mesh _movingBrick;
        private Mesh _topBrick;
        private bool _movingRight;
        private const double SideLength = 50;
        private const double BrickHeight = 8;
        private double _speed;
        private const double SpeedIncrement = 0.02;
        private readonly Random _random = new();
        private Camera _initialCamera;
        private const double MaxDisplacementCoefficient = 1.3;
        private bool _movingOnX;
        private bool _gameOver;

        public Form1()
        {
            InitializeComponent();

            // no grid
            design1.Grid.Visible = false;
            // no zoom/pan/rotate
            design1.Rotate.Enabled = false;
            design1.Zoom.Enabled = false;
            design1.Pan.Enabled = false;
            // no toolbar/viewcube
            design1.ToolBar.Visible = false;
            design1.ViewCubeIcon.Visible = false;
            // no coordinate system icon/origin symbol
            design1.CoordinateSystemIcon.Visible = false;
            design1.OriginSymbol.Visible = false;

            // antialiasing
            design1.AskForAntiAliasing = true;
            design1.AntiAliasing = true;

            // back face drawing mode
            design1.Backface.ColorMethod = backfaceColorMethodType.Cull;

            // no wait cursor
			design1.WaitCursorMode = devDept.Eyeshot.Control.waitCursorType.Never;
		}

		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            design1.SaveView(out _initialCamera);

            Init();
        }

        private void Init()
        {
            _movingRight = true;
            _movingOnX = true;
            _speed = 1;
            design1.Score = 1;
            _gameOver = false;

            design1.Entities.Clear();
            design1.RestoreView(_initialCamera);
            design1.Background.StyleMode = backgroundStyleType.LinearGradient;

            // brick at the top of the stack
            int baseHeight = 600;
            _topBrick = Mesh.CreateBox(SideLength, SideLength, baseHeight + BrickHeight);
            _topBrick.Translate(-SideLength / 2, -SideLength / 2, -baseHeight);
            SetRandomColor(_topBrick);
            design1.Entities.Add(_topBrick);

            // moving brick to be added to the stack
            _movingBrick = Mesh.CreateBox(SideLength, SideLength, BrickHeight);

            Translation translation1 = new Translation(-SideLength / 2, -SideLength / 2, BrickHeight * design1.Score);
            Translation translation2 = new Translation(-SideLength * MaxDisplacementCoefficient, 0);
            _movingBrick.TransformBy(translation1 * translation2);

            SetRandomColor(_movingBrick);
            design1.Entities.Add(_movingBrick);

            animationTimer.Interval = 10;
            animationTimer.Start();
        }

        private void CreateBlock()
        {
            _topBrick = _movingBrick;

            _movingOnX = !_movingOnX;
            _movingRight = !_movingRight;

            double lengthX = _movingBrick.BoxMax.X - _movingBrick.BoxMin.X;
            double lengthY = _movingBrick.BoxMax.Y - _movingBrick.BoxMin.Y;
            _movingBrick = Mesh.CreateBox(lengthX, lengthY, BrickHeight);

            Translation translation1 = new Translation(_topBrick.BoxMin.X - _movingBrick.BoxMin.X, _topBrick.BoxMin.Y - _movingBrick.BoxMin.Y, BrickHeight * design1.Score);
            Translation translation2;

            if (_movingOnX)
            {
                translation2 = new Translation(-SideLength * MaxDisplacementCoefficient, 0);
            }
            else
            {
                translation2 = new Translation(0, SideLength * MaxDisplacementCoefficient);
            }

            _movingBrick.TransformBy(translation1 * translation2);

            SetRandomColor(_movingBrick);
            design1.Entities.Add(_movingBrick);

            Point3D target = design1.ActiveViewport.Camera.Target;

            design1.ActiveViewport.Camera.Target = new Point3D(target.X, target.Y, target.Z + BrickHeight);
        }

        private void MoveBlock()
        {
            if (_movingOnX)
            {
                if (_movingRight)
                {
                    if (_movingBrick.BoxMax.X - _topBrick.BoxMax.X >= SideLength * MaxDisplacementCoefficient)
                    {
                        _movingRight = false;
                    }
                }
                else
                {
                    if (_movingBrick.BoxMin.X - _topBrick.BoxMin.X <= -SideLength * MaxDisplacementCoefficient)
                    {
                        _movingRight = true;
                    }
                }
            }
            else
            {
                if (_movingRight)
                {
                    if (_movingBrick.BoxMax.Y - _topBrick.BoxMax.Y >= SideLength * MaxDisplacementCoefficient)
                    {
                        _movingRight = false;
                    }
                }
                else
                {
                    if (_movingBrick.BoxMin.Y - _topBrick.BoxMin.Y <= -SideLength * MaxDisplacementCoefficient)
                    {
                        _movingRight = true;
                    }
                }
            }

            if (_movingOnX)
            {
                _movingBrick.Translate(_speed * (_movingRight ? 1 : -1), 0);
            }
            else
            {
                _movingBrick.Translate(0, _speed * (_movingRight ? 1 : -1));
            }

            design1.Entities.Regen();
            design1.Invalidate();
        }

        private void design1_KeyDown(object sender, KeyEventArgs e)
        {
            animationTimer.Stop();

            Interval intervalTopBrick;
            Interval intervalMovingBrick;

            if (_movingOnX)
            {
                intervalTopBrick = new Interval(_topBrick.BoxMin.X, _topBrick.BoxMax.X);
                intervalMovingBrick = new Interval(_movingBrick.BoxMin.X, _movingBrick.BoxMax.X);
            }
            else
            {
                intervalTopBrick = new Interval(_topBrick.BoxMin.Y, _topBrick.BoxMax.Y);
                intervalMovingBrick = new Interval(_movingBrick.BoxMin.Y, _movingBrick.BoxMax.Y);
            }

            Interval intersection = Interval.Intersection(intervalTopBrick, intervalMovingBrick);

            if (intersection.Length <= 0) // game over
            {
                if (!_gameOver)
                {
                    design1.ZoomCamera(-4000, 0.05, true);
                    design1.Background.StyleMode = backgroundStyleType.Solid;
                }

                _gameOver = true;
            }
            else
            {
                Region regionInCommon;
                if (_movingOnX)
                {
                    regionInCommon = devDept.Eyeshot.Entities.Region.CreateRectangle(intersection.Length,
                        _topBrick.BoxMax.Y - _topBrick.BoxMin.Y);
                }
                else
                {
                    regionInCommon =
                        devDept.Eyeshot.Entities.Region.CreateRectangle(_topBrick.BoxMax.X - _topBrick.BoxMin.X,
                            intersection.Length);
                }

                Color color = _movingBrick.Color;
                design1.Entities.Remove(_movingBrick);
                _movingBrick = regionInCommon.ExtrudeAsMesh(BrickHeight, 0.1, Mesh.natureType.Plain);
                SetColor(_movingBrick, color);
                design1.Entities.Add(_movingBrick);

                Translation translation1;

                if (_movingOnX)
                {
                    translation1 = new Translation(intersection.Min - _movingBrick.BoxMin.X, _topBrick.BoxMin.Y - _movingBrick.BoxMin.Y);
                }
                else
                {
                    translation1 = new Translation(_topBrick.BoxMin.X - _movingBrick.BoxMin.X, intersection.Min - _movingBrick.BoxMin.Y);
                }

                Translation translation2 = new Translation(0, 0, BrickHeight * design1.Score);

                _movingBrick.TransformBy(translation1 * translation2);

                design1.Score++;
                _speed += SpeedIncrement;

                design1.Entities.Regen();
                design1.Invalidate();

                CreateBlock();
                animationTimer.Start();
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            design1.Entities.Clear();
            design1.Focus();
            Init();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
	        MoveBlock();
        }

		private void SetColor(Mesh mesh, Color color)
        {
	        mesh.ColorMethod = colorMethodType.byEntity;
	        mesh.Color = color;
        }

		private void SetRandomColor(Mesh mesh)
        {
            mesh.ColorMethod = colorMethodType.byEntity;
            mesh.Color = Utility.GetRandomColor(_random);
        }
	}
}
