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
        DropboxClient dbx = new DropboxClient("TzSv4tHC040AAAAAAAABeD9kOiMFez3PVf_YX5pMnHowsmNtXVlUKRNFQgGmXX98");

        public async Task UploadFile()
        {
            
            

            var uploadStream = new System.IO.FileStream(_uploadFile,
                                            System.IO.FileMode.Open,
                                            System.IO.FileAccess.Read);
            var ms = new MemoryStream();
            uploadStream.CopyTo(ms);
            uploadStream.Close();
            await Upload(dbx, "/Apps/ProgressQuestWrapper", _uploadFile, ms);
            //Task.Run(() => Upload(dbx, "/Apps/ProgressQuestWrapper", _uploadFile, ms));
        }

        public async Task Download()
        {
            using (var response = await dbx.Files.DownloadAsync("/Apps/ProgressQuestWrapper" + "/" + _uploadFile))
            {
                System.IO.File.WriteAllBytes(_uploadFile, await response.GetContentAsByteArrayAsync());
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
