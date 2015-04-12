using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Scale.Storage.Blob;
using ImageResizer;

namespace ImageResizer.Api.Controllers
{
    public class ResizerController : ApiController
    {
        // POST api/values
        public async Task<string> ResizeInStorage(ResizeTo @params)
        {
            string uri = @params.Uri;
            int maxWidth = @params.MaxWidth;
            int maxHeight = @params.MaxHeight;

            // download the blob
            var storage = new AzureBlobStorage(System.Configuration.ConfigurationManager.AppSettings);
            var blob = await storage.Download(uri);

            // resize
            var resizer = new ResizerService();
            var newImage = resizer.Resize(blob.Stream, new System.Drawing.Size(maxWidth, maxHeight));

            //TODO: smelly new filename logic
            var imageUri = new Uri(uri);
            var paths = imageUri.AbsolutePath.Split('/');
            var newBlobName = paths[paths.Length - 1].Replace(".jpg", string.Format("_{0}_{1}.jpg", maxWidth, maxHeight));

            // save the blob
            
            var newUri = await storage.Upload(blob.ContainerName, newBlobName, "image/jpeg", newImage);

            // return the new URI
            return newUri;
        }
    }

    public class ResizeTo
    {
        public string Uri { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
    }
}
