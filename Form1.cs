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
        private const double SideLength = 50; // Side length of each brick
        private const double BrickHeight = 8; // Height of each brick
        private const double SpeedIncrement = 0.02; // Increment value for brick speed at each new brick
        private const double MaxDisplacementCoefficient = 1.3; // Maximum displacement ratio of the moving brick

        private Mesh _movingBrick; // The brick currently moving
        private Mesh _topBrick;    // The last brick placed on the stack
        private bool _movingRight; // Indicates if the brick is currently moving to the right
        private bool _movingOnX = true; // Indicates movement direction along X (true) or Y (false)
        private double _speed; // Current movement speed of the brick
        private bool _gameOver; // Indicates if the game is over

        private readonly Random _random = new();
        
        public Form1()
        {
            InitializeComponent();

            // Hide UI Elements
            design1.Grid.Visible = false;
            design1.ToolBar.Visible = false;
            design1.ViewCubeIcon.Visible = false;
            design1.CoordinateSystemIcon.Visible = false;
            design1.OriginSymbol.Visible = false;

            // Switch off ZPR
            design1.Rotate.Enabled = false;
            design1.Zoom.Enabled = false;
            design1.Pan.Enabled = false;

            // Enable antialiasing
            design1.AskForAntiAliasing = true;
            design1.AntiAliasing = true;

            // Back face drawing mode
            design1.Backface.ColorMethod = backfaceColorMethodType.Cull;

            // Disable wait cursor
			design1.WaitCursorMode = devDept.Eyeshot.Control.waitCursorType.Never;
		}

		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Init();
        }

        // Initializes or resets the game state and starts a new game
        private void Init()
        {
            _movingRight = true;
            _movingOnX = true;
            _speed = 1;
            design1.Score = 1;
            _gameOver = false;

            design1.Entities.Clear();
            design1.Background.StyleMode = backgroundStyleType.LinearGradient;

            // brick at the top of the stack
            int baseHeight = 600;
            _topBrick = Mesh.CreateBox(SideLength, SideLength, baseHeight + BrickHeight);
            _topBrick.Translate(-SideLength / 2, -SideLength / 2, -baseHeight);
            SetRandomColor(_topBrick);
            design1.Entities.Add(_topBrick);

            // Moving brick to be added to the stack
            _movingBrick = Mesh.CreateBox(SideLength, SideLength, BrickHeight);

            Transformation translation1 = Transformation.CreateTranslation(-SideLength / 2, -SideLength / 2, BrickHeight * design1.Score);
            Transformation translation2 = Transformation.CreateTranslation(-SideLength * MaxDisplacementCoefficient, 0);
            _movingBrick.TransformBy(translation1 * translation2);

            SetRandomColor(_movingBrick);
            design1.Entities.Add(_movingBrick);

            // Adjust camera
            design1.SetView(viewType.Isometric, true, false, -140);
            design1.PanDown(400);
            design1.PanLeft(50);

            animationTimer.Interval = 10;
            animationTimer.Start();
        }

        // Creates and positions the next moving brick at the top of the stack.
        private void CreateBlock()
        {
            _topBrick = _movingBrick;

            _movingOnX = !_movingOnX;
            _movingRight = !_movingRight;

            double lengthX = _movingBrick.BoxMax.X - _movingBrick.BoxMin.X;
            double lengthY = _movingBrick.BoxMax.Y - _movingBrick.BoxMin.Y;
            _movingBrick = Mesh.CreateBox(lengthX, lengthY, BrickHeight);

            Transformation translation1 = Transformation.CreateTranslation(_topBrick.BoxMin.X - _movingBrick.BoxMin.X, _topBrick.BoxMin.Y - _movingBrick.BoxMin.Y, BrickHeight * design1.Score);
            Transformation translation2;

            if (_movingOnX)
            {
                translation2 = Transformation.CreateTranslation(-SideLength * MaxDisplacementCoefficient, 0);
            }
            else
            {
                translation2 = Transformation.CreateTranslation(0, SideLength * MaxDisplacementCoefficient);
            }

            _movingBrick.TransformBy(translation1 * translation2);

            SetRandomColor(_movingBrick);
            design1.Entities.Add(_movingBrick);

            Point3D target = design1.ActiveViewport.Camera.Target;

            design1.ActiveViewport.Camera.Target = new Point3D(target.X, target.Y, target.Z + BrickHeight);
        }

        // Moves the current brick horizontally and updates the viewport accordingly
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

            design1.Entities.Regen(); // Regenerates the scene entities geometry
            design1.Invalidate(); // Forces the viewport redraw
        }

        // Handles brick placement logic on key press, calculates intersection and creates new brick
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

            if (intersection.Length <= 0) // No overlap: triggers Game Over
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

                Transformation translation1;

                if (_movingOnX)
                {
                    translation1 = Transformation.CreateTranslation(intersection.Min - _movingBrick.BoxMin.X, _topBrick.BoxMin.Y - _movingBrick.BoxMin.Y);
                }
                else
                {
                    translation1 = Transformation.CreateTranslation(_topBrick.BoxMin.X - _movingBrick.BoxMin.X, intersection.Min - _movingBrick.BoxMin.Y);
                }

                Transformation translation2 = Transformation.CreateTranslation(0, 0, BrickHeight * design1.Score);

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
