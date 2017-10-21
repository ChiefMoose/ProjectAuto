using System.Runtime.InteropServices;

namespace Interop.Structs
{
    /// <summary>
    /// Rectangle to be used in C++ code bases.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
