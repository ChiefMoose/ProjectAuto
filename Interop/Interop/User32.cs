using Interop.Enumerations;
using Interop.Structs;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Interop
{
    public sealed class User32
    {      
        #region Singleton implementation

        /// <summary>
        /// private constructor.
        /// </summary>
        private User32() { }

        /// <summary>
        /// Lazy implementation for C# 4.0
        /// </summary>
        private static readonly Lazy<User32> lazy =
            new Lazy<User32>(() => new User32());

        /// <summary>
        /// Instance of the <see cref="User32"/> class.
        /// </summary>
        public static User32 Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        #endregion

        #region DLLImport

        #region Window Functions

        /// <summary>
        /// Retrieves the handle to a window whos class name and window name match the specified strings.
        /// <para>
        /// This function does not perform a case sensitive search.
        /// </para>
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the parent window whose child windows are to be searched.
        /// <para>
        /// If null the function uses the desktop window as the parent window.
        /// The function then searches among the windows that are child windows of the desktop.
        /// </para>
        /// </param>
        /// <param name="hwndChildAfter">
        /// A handle to a child window.  The search begins with the next child window in the Z order.
        /// <para>
        /// The child window MUST be a direct child window of the hwndParent.        
        /// Note: if both hwndParent and hwndChild are null the function searches all top-level and message-only windows.
        /// </para>
        /// </param>
        /// <param name="lpszClass">
        /// The window class name. The class name can be any name registered with the RegisterClass or RegisterClassEx, or any of the pre-defined control-class names.
        /// </param>
        /// <param name="lpszWindow">
        /// The window name (title). if this parameter is null, all window names match
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr? hwndParent = null, IntPtr? hwndChildAfter = null, string lpszClass = null, string lpszWindow = null);

        /// <summary>
        /// The GetForegroundWindow function returns a handle to the foreground window.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Brings thread that created the specified window into the foreground and activates the window.
        /// <para>
        /// For additional information see: https://msdn.microsoft.com/en-us/library/windows/desktop/ms633539(v=vs.85).aspx.
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that should be activated and brought to the foreground.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Retrives the dimenstions of the bounding rectangle of the specified window.
        /// </summary>
        /// <param name="windowHandle">Handle of the window.</param>
        /// <param name="rectangle">Out parameter to the <see cref="RECT"/> structure.</param>
        /// <returns>
        /// If method succeeds, the return value is non zero.
        /// If the method fails, the return value is zero.
        /// </returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr windowHandle, out RECT rectangle);

        #endregion

        #region Thread Functions

        /// <summary>
        /// Retrieves the thread Identifer of the calling thread.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();

        /// <summary>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that created the window.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="lpdwProcessId">
        /// A pointer to a variable that receives the process identifier.
        /// <para>
        /// NOTE: If this parameter is not NULL this function copies the identifer of the process to the variable, otherwise it does not.
        /// </para>
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        /// <summary>
        /// Attaches or detaches the input processing mechanism of one thread to that of another thread.
        /// </summary>
        /// <param name="idAttach">
        /// Identifier of the thread to be attached to another thread.
        /// <para>
        /// The thread to be attached cannot be a system thread.
        /// </para>
        /// </param>
        /// <param name="idAttachTo">
        /// Identifier of the thread to which idAttach will be attached.
        /// <para>
        /// A thread cannot attach to itself, therefore idAttachTo cannot equal idAttach.
        /// </para>
        /// </param>
        /// <param name="fAttach">
        /// If this parameter is TRUE the two threads are attached. If the parameter is FALSE, the threads are detached.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        #endregion

        #region SendInput Functions

        /// <summary>
        /// Translates a character to the correspinding virtual-key code and shift state.
        /// </summary>
        /// <param name="ch">The character to be translated into a virtual-key code.</param>
        /// <param name="dwhkl">Input locale identifier used to translate the character.</param>
        /// <returns>
        /// Low-order byte: virtual-keycode
        /// High-order byte: shift state (which can be a combination of the following flag bits).
        /// Value:
        ///     1: Either SHIFT key is pressed.
        ///     2: Either CTRL key is pressed.
        ///     4: Either ALT key is pressed.
        ///     8: The Hankaku key is pressed.
        ///     16: Reserved (defined by the keyboard layout driver).
        ///     32: Reserved (defined by the keyboard layout driver).
        /// if the function finds no key that translates to the passed character code, both the oder bytes contain -1.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern short VkKeyScanEx(char ch, IntPtr dwhkl);

        /// <summary>
        /// Translates a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code.
        /// <para>
        /// To specify a handle to the keyboard layout to use for translating the specified code, use the <see cref="MapVirtualKey(uint, uint)"/> function.
        /// </para>
        /// </summary>
        /// <param name="uCode">
        /// the virtual-key code or scan code for a key.
        /// <para>How this value is interpreted depends on the value of the uMapType parameter.</para>
        /// </param>
        /// <param name="uMapType">
        /// The translation to be performed.  The value of this parameter depends on the value of the uCode parameter.
        /// </param>
        /// <returns>
        /// If there is no translation, this function returns 0.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, MapKey uMapType);

        /// <summary>
        /// Emulates keystrokes, mouse motions, and button clicks.
        /// </summary>
        /// <param name="numberOfInputs">
        /// The number of <see cref="INPUT"/> structures in the input array.
        /// </param>
        /// <param name="input">
        /// An array of <see cref="INPUT"/> structures.
        /// <para>
        /// Each structure represents an event to be inserted into the keyboard or mouse input stream.
        /// </para>
        /// </param>
        /// <param name="structSize">
        /// The size, in bytes of an <see cref="INPUT"/> aray.
        /// <para>
        /// If cbSize is not the size of the array, the function fails.
        /// </para>
        /// </param>
        /// <returns>
        /// Returns the number of events that is successfully inserted into the keyboard or mouse input stream.
        /// <para>
        /// If the function returns 0, the input was already blocked by another thread. To get extended error information call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern uint SendInput(uint numberOfInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] INPUT[] input, int structSize);

        #endregion

        #region ScreenCapture

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="bInheritHandle"></param>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="dwSize"></param>
        /// <param name="lpNumberOfBytesRead"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        /// <summary>
        /// Retrieves the extra message for the current thread.
        /// <para>
        /// Extra message information is an application or driver defined value associated with the current thread's message queue.
        /// </para>
        /// <para>
        /// For additional information, please see https://msdn.microsoft.com/en-us/library/windows/desktop/ms644937(v=vs.85).aspx
        /// </para>
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        /// <summary>
        /// Sets the keyboard focus to the specified window.
        /// <para>
        /// The window must be attached to the calling thread's message queue.
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that will receive the keyboard input.
        /// <para>
        /// If this parameter is NULL keystrokes are ignored.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that previously had keyboard focus 
        /// and a WM_SETFOCUS message to the window that receives the keyboard focus.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        #endregion


        public static int GetSystemMetrics(SystemMetrics nIndex)
        {
            return GetSystemMetrics((int)nIndex);
        }

        public static void SwitchWindow(IntPtr windowHandle)
        {
            if (GetForegroundWindow() == windowHandle)
                return;

            IntPtr foregroundWindowHandle = GetForegroundWindow();
            uint currentThreadId = GetCurrentThreadId();
            uint temp;
            uint foregroundThreadId = GetWindowThreadProcessId(foregroundWindowHandle, out temp);
            AttachThreadInput(currentThreadId, foregroundThreadId, true);
            SetForegroundWindow(windowHandle);
            AttachThreadInput(currentThreadId, foregroundThreadId, false);

            while (GetForegroundWindow() != windowHandle)
            {
            }
        }

        /// <summary>
        /// Returns the handle for the window name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IntPtr GetWindow(string name)
        {
            Process[] procs = Process.GetProcesses();

            foreach (Process proc in procs)
            {
                if (proc.MainWindowTitle.Equals(name))
                {
                    return proc.MainWindowHandle;
                }
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int MakeLong(int low, int high)
        {
            return (high << 16) | (low & 0xffff);
        }

        public static int GetAbsoluteXValue(int x)
        {
            return (x * ushort.MaxValue) / GetSystemMetrics(SystemMetrics.X_SCREEN_SIZE);
        }

        public static int GetAbsoluteYValue(int y)
        {
            return (y * ushort.MaxValue) / GetSystemMetrics(SystemMetrics.Y_SCREEN_SIZE);
        }
    }
}