using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressQuestWrapper
{
    class DropboxUpload
    {
        static async Task Run()
        {
            using (var dbx = new DropboxClient("TzSv4tHC040AAAAAAAABeD9kOiMFez3PVf_YX5pMnHowsmNtXVlUKRNFQgGmXX98"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
            }
        }

        public async Task UploadFile()
        {
            var dbx = new DropboxClient("TzSv4tHC040AAAAAAAABeD9kOiMFez3PVf_YX5pMnHowsmNtXVlUKRNFQgGmXX98");
            string _uploadFile = "ProgressQuest/Fithvael_2.0 [Spoltog].pq";

            var uploadStream = new System.IO.FileStream(_uploadFile,
                                            System.IO.FileMode.Open,
                                            System.IO.FileAccess.Read);
            var ms = new MemoryStream();
            uploadStream.CopyTo(ms);
            uploadStream.Close();
            await Upload(dbx, "/Apps/ProgressQuestWrapper", _uploadFile, ms);
            //Task.Run(() => Upload(dbx, "/Apps/ProgressQuestWrapper", _uploadFile, ms));
        }

        async Task Download(DropboxClient dbx, string folder, string file)
        {
            using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
            {
                Console.WriteLine(await response.GetContentAsStringAsync());
            }
        }

        async Task<FileMetadata> Upload(DropboxClient dbx, string folder, string file, MemoryStream stream)
        {
            stream.Position = 0;
            var updated = await dbx.Files.UploadAsync(
                folder + "/" + file,
                WriteMode.Overwrite.Instance,
                body: stream);
            stream.Close();
            return updated;
        }
    }
}
