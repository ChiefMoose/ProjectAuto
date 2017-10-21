using Interop.Structs;
using System;

namespace Interop.Enumerations
{
    /// <summary>
    /// Modifiers for <see cref="MOUSEINPUT.mouseData"/>.
    /// <para>
    /// For additional information, please see https://msdn.microsoft.com/en-us/library/windows/desktop/ms646273(v=vs.85).aspx.
    /// </para>   
    /// </summary>
    public enum MouseFlags : uint
    {
        /// <summary>
        /// If this flag is set the mouse will move to the absolute X and Y positions.
        /// <para>
        /// If not, the mouse will move in relation to it's current position.
        /// </para>
        /// </summary>
        ABSOLUTE = 0x8000,
        /// <summary>
        /// The wheel moves horizontally.
        /// <para>
        /// The amount of movement is specified in <see cref="MOUSEINPUT.mouseData"/>.
        /// </para>
        /// </summary>
        HWHEEL = 0x01000,
        /// <summary>
        /// Movement occured.
        /// </summary>
        MOVE = 0x0001,
        /// <summary>
        /// The <see cref="MOVE"/> modifier will not be coalesced.
        /// <para>
        /// Default behaviour is to coalesce <see cref="MOVE"/> messages.
        /// </para>
        /// </summary>
        MOVE_NOCOALESCE = 0x2000,
        /// <summary>
        /// Presses the left button down.
        /// </summary>
        LEFTDOWN = 0x0002,
        /// <summary>
        /// Releases the left button.
        /// </summary>
        LEFTUP = 0x0004,
        /// <summary>
        /// Presses the right button down.
        /// </summary>
        RIGHTDOWN = 0x0008,
        /// <summary>
        /// Releases the right button.
        /// </summary>
        RIGHTUP = 0x0010,
        /// <summary>
        /// Presses the middle button down.
        /// </summary>
        MIDDLEDOWN = 0x0020,
        /// <summary>
        /// Releases the middle button.
        /// </summary>
        MIDDLEUP = 0x0040,
        /// <summary>
        /// Maps coordinates to the entire desktip.
        /// <para>
        /// MUST be used with <see cref="ABSOLUTE"/>.
        /// </para>
        /// </summary>
        VIRTUALDESK = 0x4000,
        /// <summary>
        /// The mouse wheel was moved.
        /// <para>
        /// Amount of movement is specified in <see cref="MOUSEINPUT.mouseData"/>.
        /// </para>
        /// </summary>
        WHEEL = 0x0800,
        /// <summary>
        /// Presses the X button down.
        /// </summary>
        XDOWN = 0x0080,
        /// <summary>
        /// Releases the X button.
        /// </summary>
        XUP = 0x0100,
        [Obsolete("Does nothing.")]
        NONE = 0x000,
    }
}
