using System;

namespace Interop.Enumerations
{
    /// <summary>
    /// Modifiers for <see cref="KEYBDINPUT.dwFlags"/>.
    /// <para>
    /// For additional information, please see https://msdn.microsoft.com/en-us/library/windows/desktop/ms646271(v=vs.85).aspx.
    /// </para>
    /// </summary>
    public enum KeyboardFlags : uint
    {
        /// <summary>
        /// If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
        /// <para>
        /// Simple explanation: This action was performed from the Numeric keypad.
        /// </para>
        /// </summary>
        EXTENDEDKEY = 0x0001,
        /// <summary>
        /// if this modifier is applied, the key is being released.  Otherwise the key is being pressed.
        /// </summary>
        KEYUP = 0x0002,
        /// <summary>
        /// If this modifier is applied, the system synthesizes a VK_PACKET keystroke.
        /// The <see cref="KEYBDINPUT.wVk"/> parameter MUST be 0.
        /// <para>
        /// This modifier can only be combined with the <see cref="KEYEVENTF_KEYUP"/> modifier.
        /// </para>
        /// </summary>
        UNICODE = 0x0004,
        /// <summary>
        /// If this modifier is applied, <see cref="KEYBDINPUT.wScan"/> identifies the key and <see cref="KEYBDINPUT.wVk"/> is ignored.
        /// </summary>
        SCANCODE = 0x0008,
        /// <summary>
        /// Performs no action.
        /// </summary>
        [Obsolete("This enum is not used.")]
        NONE = 0,
    }
}
