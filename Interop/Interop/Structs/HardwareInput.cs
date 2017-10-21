
using System.Runtime.InteropServices;

namespace Interop.Structs
{
    /// <summary>
    /// Used to emulate hardware functionality.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        uint uMsg;
        ushort wParamL;
        ushort wParamH;
    }
}