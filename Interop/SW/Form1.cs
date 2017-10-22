using ImageComparison;
using Interop;
using Interop.SendInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Process[] processes = Process.GetProcesses();
            MouseClick += Labe1_MouseClick;

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

            Rectangle skipCheckMark = new Rectangle(
                (int)(summonersWar.Rectangle.Left + (summonersWar.Rectangle.Width * .11807)),
                (int)(summonersWar.Rectangle.Top + (summonersWar.Rectangle.Height * .82097)),
                (int)((summonersWar.Rectangle.Width * .15180) - (summonersWar.Rectangle.Width * .11807)),
                (int)((summonersWar.Rectangle.Height * .87160) - (summonersWar.Rectangle.Height * .82097)));

            Bitmap image = ScreenCapture.CaptureBitmapImage(skipCheckMark);
            double dif = ScreenCapture.GetImageDifference(image, image);
            ScreenCapture.SaveBitmapImage(image, "c:\\temp.bmp");
            image.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScreenDraw.DrawToScreen();
            Point mousePos = new Point();
            Mouse.GetCurrentPosition(out mousePos);
            label1.Text = string.Format("x:{0} y:{1}", mousePos.X, mousePos.Y);
        }

        private void Labe1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = string.Format("x:{0} y:{1}", e.X, e.Y);
            new Point(e.X, e.Y);
        }
    }
}