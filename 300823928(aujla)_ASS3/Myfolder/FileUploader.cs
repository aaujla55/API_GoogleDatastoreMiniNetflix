using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _300823928_aujla__ASS3.Myfolder
{
    public class FileUploader
    {
    private readonly string _bucketName = "my-test11";
    private readonly StorageClient _storageClient;

    public FileUploader(string bucketName)
    {
        _bucketName = bucketName;
        // [START storageclient]
        _storageClient = StorageClient.Create();
        // [END storageclient]
    }

    // [START uploadimage]
    public async Task<String> UploadFile(HttpPostedFileBase file, long id)
    {
        var imageAcl = PredefinedObjectAcl.PublicRead;

        var imageObject = await _storageClient.UploadObjectAsync(
            bucket: _bucketName,
            objectName: id.ToString(),
            contentType: file.ContentType,
            source: file.InputStream,
            options: new UploadObjectOptions { PredefinedAcl = imageAcl }
        );

        return imageObject.MediaLink;
    }
    // [END uploadimage]

    public async Task DeleteUploadedImage(long id)
    {
        try
        {
            await _storageClient.DeleteObjectAsync(_bucketName, id.ToString());
        }
        catch (Google.GoogleApiException exception)
        {
            // A 404 error is ok.  The image is not stored in cloud storage.
            if (exception.Error.Code != 404)
                throw;
        }
    }
}
}
