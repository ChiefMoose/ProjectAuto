using System;
using System.Runtime.InteropServices;

namespace Interop.Structs
{
    /// <summary>
    /// Used to emulate keyboard functionality.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
}
