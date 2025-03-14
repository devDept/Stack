namespace Stack
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            devDept.Eyeshot.Control.CancelToolBarButton cancelToolBarButton1 = new devDept.Eyeshot.Control.CancelToolBarButton("Cancel", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.ProgressBar progressBar1 = new devDept.Eyeshot.Control.ProgressBar(devDept.Eyeshot.Control.ProgressBar.styleType.Speedometer, 0, "Idle", Color.Black, Color.Transparent, Color.Green, 1D, true, cancelToolBarButton1, false, 0.1D, 0.333D, true);
            devDept.Eyeshot.Control.BackgroundSettings backgroundSettings1 = new devDept.Eyeshot.Control.BackgroundSettings(devDept.Graphics.backgroundStyleType.LinearGradient, Color.FromArgb(8, 206, 225), Color.DodgerBlue, Color.FromArgb(18, 57, 81), 0.75D, null, devDept.Eyeshot.colorThemeType.Auto, 0.33D);
            devDept.Eyeshot.Camera camera1 = new devDept.Eyeshot.Camera(new devDept.Geometry.Point3D(0D, 0D, 45D), 380D, new devDept.Geometry.Quaternion(0.018434349666532526D, 0.039532590434972079D, 0.42221602280006187D, 0.90544518284475428D), devDept.Eyeshot.projectionType.Perspective, 40D, 4.9800006370119325D, false, 0.001D);
            devDept.Eyeshot.Control.HomeToolBarButton homeToolBarButton1 = new devDept.Eyeshot.Control.HomeToolBarButton("Home", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.Control.MagnifyingGlassToolBarButton magnifyingGlassToolBarButton1 = new devDept.Eyeshot.Control.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.ZoomWindowToolBarButton zoomWindowToolBarButton1 = new devDept.Eyeshot.Control.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.ZoomToolBarButton zoomToolBarButton1 = new devDept.Eyeshot.Control.ZoomToolBarButton("Zoom", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.PanToolBarButton panToolBarButton1 = new devDept.Eyeshot.Control.PanToolBarButton("Pan", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.RotateToolBarButton rotateToolBarButton1 = new devDept.Eyeshot.Control.RotateToolBarButton("Rotate", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.ZoomFitToolBarButton zoomFitToolBarButton1 = new devDept.Eyeshot.Control.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.Control.ToolBar toolBar1 = new devDept.Eyeshot.Control.ToolBar(devDept.Eyeshot.Control.ToolBar.positionType.HorizontalTopCenter, true, new devDept.Eyeshot.Control.ToolBarButton[] { homeToolBarButton1, magnifyingGlassToolBarButton1, zoomWindowToolBarButton1, zoomToolBarButton1, panToolBarButton1, rotateToolBarButton1, zoomFitToolBarButton1 }, 5, 0, Color.FromArgb(0, 0, 0, 0), 0D, Color.FromArgb(0, 0, 0, 0), 0D);
            devDept.Eyeshot.Control.LegendItem legendItem1 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(0, 0, 255));
            devDept.Eyeshot.Control.LegendItem legendItem2 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(0, 127, 255));
            devDept.Eyeshot.Control.LegendItem legendItem3 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(0, 255, 255));
            devDept.Eyeshot.Control.LegendItem legendItem4 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(0, 255, 127));
            devDept.Eyeshot.Control.LegendItem legendItem5 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(0, 255, 0));
            devDept.Eyeshot.Control.LegendItem legendItem6 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(127, 255, 0));
            devDept.Eyeshot.Control.LegendItem legendItem7 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(255, 255, 0));
            devDept.Eyeshot.Control.LegendItem legendItem8 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(255, 127, 0));
            devDept.Eyeshot.Control.LegendItem legendItem9 = new devDept.Eyeshot.Control.LegendItem(10, 30, Color.FromArgb(255, 0, 0));
            devDept.Eyeshot.Control.Legend legend1 = new devDept.Eyeshot.Control.Legend(0D, 100D, "Title", "Subtitle", new Point(24, 24), true, false, false, "{0:+0.###;-0.###;0}", Color.Transparent, Color.Black, Color.Black, null, null, new devDept.Eyeshot.Control.LegendItem[] { legendItem1, legendItem2, legendItem3, legendItem4, legendItem5, legendItem6, legendItem7, legendItem8, legendItem9 }, true, false, false, 0);
            devDept.Eyeshot.Control.Histogram histogram1 = new devDept.Eyeshot.Control.Histogram(30, 80, "Title", Color.Blue, Color.Gray, Color.Black, Color.Red, Color.LightYellow, false, true, false, "{0:+0.###;-0.###;0}");
            devDept.Eyeshot.Control.Grid grid1 = new devDept.Eyeshot.Control.Grid(new devDept.Geometry.Point2D(-100D, -100D), new devDept.Geometry.Point2D(100D, 100D), 10D, new devDept.Geometry.Plane(new devDept.Geometry.Point3D(0D, 0D, 0D), new devDept.Geometry.Vector3D(1D, 0D, 0D), new devDept.Geometry.Vector3D(0D, 1D, 0D)), Color.FromArgb(63, 128, 128, 128), Color.FromArgb(127, 255, 0, 0), Color.FromArgb(127, 0, 128, 0), false, true, false, false, 10, 100, 10, Color.FromArgb(127, 90, 90, 90), Color.Transparent, false, Color.FromArgb(12, 0, 0, 255));
            devDept.Eyeshot.Control.OriginSymbol originSymbol1 = new devDept.Eyeshot.Control.OriginSymbol(10, devDept.Eyeshot.Control.originSymbolStyleType.Ball, new Font("Segoe UI", 9F), Color.Black, Color.Black, Color.Black, Color.Black, Color.Red, Color.Green, Color.Blue, "Origin", "X", "Y", "Z", true, null, false);
            devDept.Eyeshot.Control.RotateSettings rotateSettings1 = new devDept.Eyeshot.Control.RotateSettings(new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.None), 10D, true, 1D, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, new devDept.Geometry.Point3D(0D, 0D, 0D), false);
            devDept.Eyeshot.Control.ZoomSettings zoomSettings1 = new devDept.Eyeshot.Control.ZoomSettings(new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Shift), 25, true, devDept.Eyeshot.zoomStyleType.AtCursorLocation, false, 1D, Color.Empty, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, false, 10, true);
            devDept.Eyeshot.Control.PanSettings panSettings1 = new devDept.Eyeshot.Control.PanSettings(new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Ctrl), 25, true);
            devDept.Eyeshot.Control.NavigationSettings navigationSettings1 = new devDept.Eyeshot.Control.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Left, devDept.Eyeshot.Control.modifierKeys.None), new devDept.Geometry.Point3D(-1000D, -1000D, -1000D), new devDept.Geometry.Point3D(1000D, 1000D, 1000D), 8D, 50D, 50D);
            devDept.Eyeshot.Control.CoordinateSystemIcon coordinateSystemIcon1 = new devDept.Eyeshot.Control.CoordinateSystemIcon(new Font("Segoe UI", 9F), Color.Black, Color.Black, Color.Black, Color.Black, Color.FromArgb(80, 80, 80), Color.FromArgb(80, 80, 80), Color.OrangeRed, "Origin", "X", "Y", "Z", true, devDept.Eyeshot.Control.coordinateSystemPositionType.BottomLeft, 37, null, false);
            devDept.Eyeshot.Control.ViewCubeIcon viewCubeIcon1 = new devDept.Eyeshot.Control.ViewCubeIcon(devDept.Eyeshot.Control.coordinateSystemPositionType.TopRight, true, Color.FromArgb(220, 20, 60), true, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", Color.FromArgb(240, 77, 77, 77), Color.FromArgb(240, 77, 77, 77), Color.FromArgb(240, 77, 77, 77), Color.FromArgb(240, 77, 77, 77), Color.FromArgb(240, 77, 77, 77), Color.FromArgb(240, 77, 77, 77), 'S', 'N', 'W', 'E', true, null, Color.White, Color.Black, 120, true, true, null, null, null, null, null, null, false, new devDept.Geometry.Quaternion(0D, 0D, 0D, 1D), true);
            devDept.Eyeshot.Control.ScaleBar scaleBar1 = new devDept.Eyeshot.Control.ScaleBar();
            devDept.Eyeshot.Control.Viewport viewport1 = new devDept.Eyeshot.Control.Viewport(new Point(0, 0), new Size(860, 498), backgroundSettings1, camera1, new devDept.Eyeshot.Control.ToolBar[] { toolBar1 }, new devDept.Eyeshot.Control.Legend[] { legend1 }, histogram1, devDept.Eyeshot.displayType.Rendered, true, false, false, new devDept.Eyeshot.Control.Grid[] { grid1 }, new devDept.Eyeshot.Control.OriginSymbol[] { originSymbol1 }, false, rotateSettings1, zoomSettings1, panSettings1, navigationSettings1, coordinateSystemIcon1, viewCubeIcon1, scaleBar1);
            restartButton = new Button();
            animationTimer = new System.Windows.Forms.Timer(components);
            keyLabel = new Label();
            design1 = new MyDesign();
            ((System.ComponentModel.ISupportInitialize)design1).BeginInit();
            SuspendLayout();
            // 
            // restartButton
            // 
            restartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            restartButton.Location = new Point(12, 516);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(77, 33);
            restartButton.TabIndex = 1;
            restartButton.Text = "Restart";
            restartButton.Click += restartButton_Click;
            // 
            // animationTimer
            // 
            animationTimer.Tick += animationTimer_Tick;
            // 
            // keyLabel
            // 
            keyLabel.AutoSize = true;
            keyLabel.Location = new Point(95, 525);
            keyLabel.Name = "keyLabel";
            keyLabel.Size = new Size(158, 15);
            keyLabel.TabIndex = 2;
            keyLabel.Text = "Press a key to drop the block";
            // 
            // design1
            // 
            design1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            design1.Location = new Point(12, 12);
            design1.Name = "design1";
            design1.ProgressBar = progressBar1;
            design1.Size = new Size(860, 498);
            design1.TabIndex = 0;
            design1.Text = "design1";
            design1.Viewports.Add(viewport1);
            design1.KeyDown += design1_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(design1);
            Controls.Add(keyLabel);
            Controls.Add(restartButton);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stack";
            ((System.ComponentModel.ISupportInitialize)design1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button restartButton;
		private System.Windows.Forms.Timer animationTimer;
        private Label keyLabel;
        private MyDesign design1;
    }
}
