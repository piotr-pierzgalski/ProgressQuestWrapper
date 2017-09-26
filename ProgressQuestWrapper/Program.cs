using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressQuestWrapper
{
    static class Program
    {
        private static int failedAttemptCounter = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PerformDownload(failedAttemptCounter);
            Application.Run(new WrapperForm());
            Application.ApplicationExit += OnApplicationExit;
            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }

        static void OnApplicationExit(object sender, EventArgs eventArgs)
        {
            DropboxUpload du = new DropboxUpload();

            du.UploadFile().Wait();
        }

        private static void PerformDownload(int failedCount)
        {
            try
            {
                DropboxUpload du = new DropboxUpload();
                du.Download().Wait();
            }
            catch (Exception e)
            {
                if (failedCount < 20)
                {
                    Thread.Sleep(3000);
                    PerformDownload(++failedCount);
                }
                else
                {
                    throw new Exception("Exceeded maximum download failed count threshold of 20");
                }
            }
        }
    }
}
