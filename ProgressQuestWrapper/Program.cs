using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressQuestWrapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DropboxUpload du = new DropboxUpload();
            du.Download().Wait();
            Application.Run(new WrapperForm());

            Application.ApplicationExit += OnApplicationExit;
            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
        }

        static void OnApplicationExit(object sender, EventArgs eventArgs)
        {
            DropboxUpload du = new DropboxUpload();

            du.UploadFile().Wait();
        }
    }
}
