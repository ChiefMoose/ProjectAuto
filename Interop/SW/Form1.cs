using ImageComparison;
using Interop;
using Interop.Enumerations;
using Interop.SendInput;
using Interop.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SW
{
    public partial class Form1 : Form
    {
        private IntPtr _processHandle;

        public Form1()
        {
            InitializeComponent();

            Process[] processes = Process.GetProcesses();

            List<string> processNames = new List<string>();
            foreach (Process p in processes)
            {
                if (p.MainWindowHandle !=  IntPtr.Zero)
                {
                    processNames.Add(p.ProcessName);
                }                
            }
            listBox1.Items.AddRange(processNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();

            App summonersWar = new App(processes.First(process => process.ProcessName.Contains(listBox1.SelectedItem.ToString()) && process.MainWindowHandle != IntPtr.Zero));
            
            label1.Text = summonersWar.Rectangle.Left + " " + summonersWar.Rectangle.Top;

            Mouse.MoveMouse(summonersWar.Rectangle.Left, summonersWar.Rectangle.Top);

            Bitmap image = ScreenCapture.CaptureBitmapImage(summonersWar.Rectangle);
            double dif = ScreenCapture.GetImageDifference(image, image);
            ScreenCapture.SaveBitmapImage(image, "c:\\temp.bmp");
            image.Dispose();
        }
    }
}