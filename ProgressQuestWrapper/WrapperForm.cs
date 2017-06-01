using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ProgressQuestWrapper
{
    public partial class WrapperForm : Form
    {
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private IntPtr progressQuestWindowHandle;
        public WrapperForm()
        {
            InitializeComponent();

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo() { FileName = "ProgressQuest\\Fithvael_2.0 [Spoltog].pq" };
            p.Start();
            p.WaitForInputIdle(); // Allow the process to open it's window
            progressQuestWindowHandle = FindWindowByCaption(IntPtr.Zero, "ProgressQuest - Fithvael_2.0 [Spoltog]");


            RECT rct;
            if (!GetWindowRect(new HandleRef(wrapperPanel, progressQuestWindowHandle), out rct))//p.MainWindowHandle
            {
                MessageBox.Show("ERROR");
                return;
            }

            //wrapperPanel.Dock = DockStyle.Fill;

            this.Height = 700;//rct.Bottom - rct.Top + 100;
            this.Width = 700;//rct.Right - rct.Left + 40;
            //wrapperPanel.Height = 660;

            SetParent(progressQuestWindowHandle, wrapperPanel.Handle);
            //MoveWindow(progressQuestWindowHandle, this.Left + 11, this.Top + 40, this.Width - 40, this.Height - 80, true);
            MoveWindow(progressQuestWindowHandle, 1, 1, wrapperPanel.Width-7, wrapperPanel.Height-7, true);

            if (rkApp != null && rkApp.GetValue("ProgressQuestWrapper") == null)
            {
                autostartStatusCheckbox.Checked = false;
            }
            else
            {
                autostartStatusCheckbox.Checked = true;
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private const UInt32 WM_CLOSE = 0x0010;

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

        void CloseWindow(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        private void autostartStatusCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (autostartStatusCheckbox.Checked)
            {
                rkApp.SetValue("ProgressQuestWrapper", Application.ExecutablePath);
            }
            else
            {
                rkApp.DeleteValue("ProgressQuestWrapper", false);
            }
        }

        private void WrapperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWindow(progressQuestWindowHandle);
        }

        private void syncButton_Click(object sender, EventArgs e)
        {

        }

        private void wrapperPanel_SizeChanged(object sender, EventArgs e)
        {
            MoveWindow(progressQuestWindowHandle, 1, 1, wrapperPanel.Width - 7, wrapperPanel.Height - 7, true);
        }
    }
}
