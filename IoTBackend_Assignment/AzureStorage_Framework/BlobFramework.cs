using IoTBackend.Interfaces;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace AzureStorage_Framework
{
    public class BlobFramework : IBlobFramework
    {
      
        /// <summary>
        /// Get The Blob Content in Raw Text Format
        /// </summary>
        /// <param name="url">string url for the blob file</param>
        /// <returns>blob Content in String Format</returns>
        public string GetBlobContent(string url)
        {
            var uri = new Uri(url);
            var blobReference = new CloudBlob(uri);
            string rawContent = string.Empty;

            using (var memoryStream = new MemoryStream())
            {
                blobReference.DownloadToStream(memoryStream);
                rawContent = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return rawContent;
        }
    }
}
