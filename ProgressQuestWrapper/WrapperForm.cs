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
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Upload;
using System.Security.Cryptography.X509Certificates;

namespace ProgressQuestWrapper
{
    public partial class WrapperForm : Form
    {

        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private IntPtr progressQuestWindowHandle;
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        public WrapperForm()
        {
            InitializeComponent();

            ShowInTaskbar = false;
            this.Visible = false;

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo() { FileName = "ProgressQuest\\Fithvael_2.0 [Spoltog].pq" };
            p.Start();
            p.WaitForInputIdle();
            progressQuestWindowHandle = FindWindowByCaption(IntPtr.Zero, "ProgressQuest - Fithvael_2.0 [Spoltog]");

            RECT rct;
            if (!GetWindowRect(new HandleRef(wrapperPanel, progressQuestWindowHandle), out rct))
            {
                MessageBox.Show("ERROR");
                return;
            }


            this.Height = 700;
            this.Width = 700;

            SetParent(progressQuestWindowHandle, wrapperPanel.Handle);
            MoveWindow(progressQuestWindowHandle, 1, 1, wrapperPanel.Width - 7, wrapperPanel.Height - 7, true);

            if (rkApp != null && rkApp.GetValue("ProgressQuestWrapper") == null)
            {
                autostartStatusCheckbox.Checked = false;
            }
            else
            {
                autostartStatusCheckbox.Checked = true;
            }
            WindowState = FormWindowState.Minimized;
            this.Visible = true;
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
        private const UInt32 WM_SYSCOMMAND = 0x0112;

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);


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
            //GoogleDriveUpload.uploadFile();
            DropboxUpload du = new DropboxUpload();
            du.UploadFile();
        }

        private void wrapperPanel_SizeChanged(object sender, EventArgs e)
        {
            MoveWindow(progressQuestWindowHandle, 1, 1, wrapperPanel.Width - 7, wrapperPanel.Height - 7, true);
        }

        private void WrapperForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;

                SendMessage(progressQuestWindowHandle, WM_SYSCOMMAND, new IntPtr(0xF020), IntPtr.Zero);
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }
    }
}
