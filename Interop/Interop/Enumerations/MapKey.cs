
namespace Interop.Enumerations
{
    /// <summary>
    /// Translation between virtual-keys and scan codes.
    /// </summary>
    public enum MapKey : uint
    {
        /// <summary>
        /// uCode is a virtual-key code and is translated into a scan code.
        /// </summary>
        VIRTUALKEY_TO_SCANCODE = 0,
        /// <summary>
        /// uCode is a scan code and is translated into a virtual-key code.
        /// </summary>
        SCANCODE_TO_VIRTUALKEY = 1,
        /// <summary>
        /// the uCode is a virtual key and is translated into an unshifted character value in the low-order word of the return value.
        /// </summary>
        VIRTUALKEY_TO_CHAR = 2,
        /// <summary>
        /// uCode is a scan code and is translated into a virtual-key code that distinguishes between left and right hand keys (Numpad).
        /// </summary>
        SCANCODE_TO_VIRTKALKEY_EX = 3,
    }
}
