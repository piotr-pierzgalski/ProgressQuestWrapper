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
        string _uploadFile = "ProgressQuest/Fithvael_2.0 [Spoltog].pq";
        private string discFile = "ProgressQuest\\Fithvael_2.0 [Spoltog].pq";
        DropboxClient dbx = new DropboxClient("TzSv4tHC040AAAAAAAABeD9kOiMFez3PVf_YX5pMnHowsmNtXVlUKRNFQgGmXX98");

        public async Task UploadFile()
        {
            try
            {
                var uploadStream = new System.IO.FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, discFile),
                                            System.IO.FileMode.Open,
                                            System.IO.FileAccess.Read);
                var ms = new MemoryStream();
                uploadStream.CopyTo(ms);
                uploadStream.Close();
                await Upload(dbx, "/Apps/ProgressQuestWrapper", _uploadFile, ms);
                //Task.Run(() => Upload(dbx, "/Apps/ProgressQuestWrapper", _uploadFile, ms));
            }
            catch(Exception ex)
            {

            }
        }

        public FileMetadata UploadFileNotAsync()
        {
            try
            {
                var uploadStream = new System.IO.FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, discFile),
                                            System.IO.FileMode.Open,
                                            System.IO.FileAccess.Read);
                var ms = new MemoryStream();
                uploadStream.CopyTo(ms);
                uploadStream.Close();
                return UploadNotAsync(dbx, "/Apps/ProgressQuestWrapper", _uploadFile, ms);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Download()
        {
            using (var response = await dbx.Files.DownloadAsync("/Apps/ProgressQuestWrapper" + "/" + _uploadFile))
            {
                System.IO.File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, discFile), await response.GetContentAsByteArrayAsync());
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

        FileMetadata UploadNotAsync(DropboxClient dbx, string folder, string file, MemoryStream stream)
        {
            stream.Position = 0;
            var x = dbx.Files.UploadAsync(
                folder + "/" + file,
                WriteMode.Overwrite.Instance,
                body: stream).Result;
            stream.Close();
            return x;
        }
    }
}
