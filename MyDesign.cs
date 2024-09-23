using devDept.Eyeshot;
using devDept.Eyeshot.Control;

namespace Stack
{
    internal class MyDesign : Design
    {
        public int Score;

        public MyDesign()
        {
            Font = new Font(FontFamily.GenericSansSerif, 40);
        }

        protected override void DrawOverlay(DrawSceneParams myParams)
        {
            string scoreToDisplay = (Score - 1).ToString();

            if (scoreToDisplay != "0")
            {
                DrawText(Size.Width / 2, Size.Height - 70, scoreToDisplay, Font, Color.FromArgb(200, Color.White), ContentAlignment.MiddleCenter);
            }

            base.DrawOverlay(myParams);
        }
    }
}