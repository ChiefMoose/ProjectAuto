using Interop.SendInput;
using System;
using System.Drawing;

namespace ImageComparison
{
    public static class ScreenDraw
    {

        public static void DrawToScreen()
        {
            Point pt = new Point();
            Mouse.GetCurrentPosition(out pt); // Get the mouse cursor in screen coordinates

            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                g.DrawEllipse(Pens.Black, pt.X - 10, pt.Y - 10, 20, 20);
            }
        }
    }
}
