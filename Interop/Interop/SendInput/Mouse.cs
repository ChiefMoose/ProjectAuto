using Interop.Enumerations;
using Interop.Structs;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Interop.SendInput
{
    public static class Mouse
    {
        public static MOUSEINPUT CreateMouseInput(Point point, uint mouseData, uint dwFlags)
        {
            return CreateMouseInput(point.X, point.Y, mouseData, dwFlags);
        }

        public static MOUSEINPUT CreateMouseInput(int x, int y, uint mouseData, uint dwFlags)
        {
            MOUSEINPUT mi = new MOUSEINPUT();
            mi.dx = User32.GetAbsoluteXValue(x);
            mi.dy = User32.GetAbsoluteYValue(y);
            mi.mouseData = mouseData;
            mi.time = 0;
            mi.dwFlags = dwFlags;

            return mi;
        }

        public static bool MoveMouse(int x, int y)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0].mi = CreateMouseInput(x, y, 0, (uint)MouseFlags.MOVE | (uint)MouseFlags.ABSOLUTE);

            if (User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT))) == inputs.Length)
            {
                return true;
            }
            return false;
        }

        public static void MoveMouse(IList<Point> points)
        {
            foreach (Point point in points)
            {
                MoveMouse(point.X, point.Y);
            }            
        }
    }
}