using System;

namespace Interop.Enumerations
{
    /// <summary>
    /// Parameters to be used with <see cref="User32.GetSystemMetrics(SystemMetrics)"/>.
    /// <para> For additional info, please see https://msdn.microsoft.com/en-us/library/windows/desktop/ms724385(v=vs.85).aspx. </para>
    /// </summary>
    public enum SystemMetrics : int
    {
        /// <summary>
        /// Flags that specify how the system arranged minimized windows.
        /// </summary>
        ARRANGE = 56,
        /// <summary>
        /// The value that specifies how the system is started:
        /// <para/> 0 Normal Boot
        /// <para/> 1 Fail-safe boot
        /// <para/> 2 Fail-safe with network boot
        /// </summary>
        CLEANBOOT = 67,
        /// <summary>
        /// The number of display monitors on a desktop.
        /// </summary>
        MONITORS = 80,
        /// <summary>
        /// The number of buttons on a mouse, or 0 if no mouse is installed.
        /// </summary>
        MOUSE_BUTTONS = 43,
        /// <summary>
        /// Reflects the state of the laptop or slate mode.
        /// <para>0 for slate mode and non zero otherwise.</para>
        /// </summary>
        CONVERTIBLE_SLATE_MODE = 0x2003,
        /// <summary>
        /// The width of a window border in pixels.
        /// <para>
        /// This is equivalent to the <see cref="X_EDGE"/> value for windows with the 3d look.
        /// </para>
        /// </summary>
        WIDTH_WINDOW_BORDER = 5,
        /// <summary>
        /// The width of a cursor in pixels.
        /// </summary>
        WIDTH_CURSOR = 13,
        [Obsolete]
        WIDTH_DIALOG_FRAME = 7,

        X_SCREEN_SIZE = 0,
        Y_SCREEN_SIZE = 1,
        X_EDGE = 45,
    }
}
