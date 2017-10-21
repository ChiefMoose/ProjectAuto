﻿using Interop;
using Interop.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW
{
    public class App
    {
        private RECT _rectangle;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    _rectangle.Left,
                    _rectangle.Top,
                    _rectangle.Right - _rectangle.Left,
                    _rectangle.Bottom - _rectangle.Top);
            }
        }

        private Process _process;
        public Process Process
        {
            get
            {
                return _process;
            }
        }

        private IntPtr _windowHandle;
        public IntPtr ApplicationHandle
        {
            get
            {
                return _windowHandle;
            }
        }

        public App(Process application)
        {
            _process = application;
            User32.GetWindowRect(application.MainWindowHandle, out _rectangle);
        }

        public App( string windowName)
        {
            _windowHandle = User32.GetWindow(windowName);
            User32.GetWindowRect(_windowHandle, out _rectangle);
        }
    }
}
