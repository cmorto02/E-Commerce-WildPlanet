using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Utilities
{
    public class Blob
    {
        public CloudStorageAccount CloudStorage { get; set; }
        public CloudBlobClient CloudBlob { get; set; }
        public Blob(IConfiguration configuration)
        {
            CloudStorage = CloudStorageAccount.Parse(configuration["AzureBlobConnectionString"]);
            CloudBlob = CloudStorage.CreateCloudBlobClient();
        }

        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlob.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            return cbc;
        }

        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);
            return blob;
        }

        public async void UploadFile(CloudBlobContainer container, string fileName, string filePath)
        {
            CloudBlockBlob blobFile = container.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);
        }
    }
}
