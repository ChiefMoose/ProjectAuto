using System.Runtime.InteropServices;

namespace Interop.Structs
{
    /// <summary>
    /// Use for 64 bit applications.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT64
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(8)] //*
        public MOUSEINPUT mi;
        [FieldOffset(8)] //*
        public KEYBDINPUT ki;
        [FieldOffset(8)] //*
        public HARDWAREINPUT hi;
    }
}