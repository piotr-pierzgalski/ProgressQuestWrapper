using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressQuestWrapper
{
    class GoogleDriveUpload
    {
        static string[] Scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                             DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                             DriveService.Scope.DriveReadonly,   // view your drive apps
                                             DriveService.Scope.DriveFile,   // view and manage files created by this app
                                             DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                             DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                             DriveService.Scope.DriveScripts };
        static string ApplicationName = "ProgressQuestWrapper";

        private static DriveService CreateService()
        {
            UserCredential credential;

            using (var stream =
            new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(@"c:\datastore", true)//new FileDataStore(credPath, true)
                    ).Result;
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        public static void uploadFile()
        {
            var _service = CreateService();

            string _uploadFile = "ProgressQuest/Fithvael_2.0 [Spoltog].pq";
            var uploadStream = new System.IO.FileStream(_uploadFile,
                                            System.IO.FileMode.Open,
                                            System.IO.FileAccess.Read);
            // Get the media upload request object.

            Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
            body.Title = "ProgressQuest/Fithvael_2.0 [Spoltog].pq";
            body.Description = "descr";
            body.MimeType = "text/plain";

            FilesResource.InsertMediaUpload request = _service.Files.Insert(
                body, uploadStream, "text/plain");
            //request.Fields = "id";
            var progress = request.Upload();
            Console.WriteLine(progress.Status.ToString() + " " + progress.BytesSent);
        }
    }
}
