using System;
using System.Runtime.InteropServices;

namespace Interop.Structs
{
    /// <summary>
    /// Used to emulate mouse functionality.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. 
        /// <para>Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved.</para>
        /// </summary>
        public int dx;
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. 
        /// <para>Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved.</para>
        /// </summary>
        public int dy;
        /// <summary>
        /// If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement. 
        /// A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. 
        /// One wheel click is defined as WHEEL_DELTA, which is 120.
        /// <para>
        /// Windows Vista: If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel movement.
        /// </para>
        /// <para>
        /// A positive value indicates that the wheel was rotated to the right;
        /// a negative value indicates that the wheel was rotated to the left.
        /// One wheel click is defined as WHEEL_DELTA, which is 120.
        /// </para>
        /// <para>If dwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then mouseData should be zero.</para>
        /// <para>If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X buttons were pressed or released.</para>
        /// </summary>
        public uint mouseData;
        /// <summary>
        /// A set of bit flags that specify various aspects of mouse motion and button clicks.
        /// <para>
        /// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions.
        /// </para>
        /// <para>For example, if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN is set when the left button is first pressed, but not for subsequent motions.
        /// Similarly, MOUSEEVENTF_LEFTUP is set only when the button is first released.
        /// You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP flags simultaneously in the dwFlags parameter, 
        /// because they both require use of the mouseData field.
        /// </para>
        /// </summary>
        public uint dwFlags;
        /// <summary>
        /// Time stamp for the event, in miliseconds.
        /// <para>
        /// If this parameter is 0, the system will provide it's own timestamp.
        /// </para>
        /// </summary>
        public uint time;
        /// <summary>
        /// An additional value associated with the mouse event.
        /// <para>
        /// An application calls <see cref="User32.GetMessageExtraInfo"/> to obtain this extra information.
        /// </para>
        /// </summary>
        public IntPtr dwExtraInfo;
    }
}
