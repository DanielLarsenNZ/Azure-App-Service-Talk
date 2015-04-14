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
    /// <summary>
    /// Resizes images in Blob Storage.
    /// </summary>
    public class ResizerController : ApiController
    {
        /// <summary>
        /// Re-sizes a JPEG image that is stored in Blob Storage to a max width and height, maintaining aspect ratio.
        /// </summary>
        /// <param name="params">A JSON or XML model object that must contain uri (string), maxWidth (int) and maxHeight (int).</param>
        /// <returns>The URL of the new, resized JPEG image.</returns>
        /// <remarks>Original image Blob must be in the Storage Account that is configured in appSettings. Resized image will be saved
        /// in to a Container named 'resized' (it will be created if it does not exist). If the resized image already exists, it will be overwritten.</remarks>
        public async Task<HttpResponseMessage> ResizeInStorage(ResizeTo @params)
        {
            string uri = @params.Uri;
            int maxWidth = @params.MaxWidth;
            int maxHeight = @params.MaxHeight;
            string storageAccount = System.Configuration.ConfigurationManager.AppSettings["AZURE_STORAGE_ACCOUNT"];

            // checks
            if (!uri.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase))
                return ErrorResponse(new NotSupportedException("Only JPEG (.jpg) Images are supported."));
            if (string.IsNullOrEmpty(storageAccount)) return ErrorResponse(new InvalidOperationException("AZURE_STORAGE_ACCOUNT was not found in AppSettings."));
            if (!uri.Contains(storageAccount)) 
                return ErrorResponse(new InvalidOperationException("Source Image blob must be in the Storage account configured for this API."));
            if (maxWidth < 0 || maxWidth > 10000) return ErrorResponse(new ArgumentOutOfRangeException("maxWidth"));
            if (maxHeight < 0 || maxHeight > 10000) return ErrorResponse(new ArgumentOutOfRangeException("maxHeight"));

            // download the blob
            var storage = new AzureBlobStorage(System.Configuration.ConfigurationManager.AppSettings);
            var blob = await storage.Download(uri);

            // resize
            var resizer = new ResizerService();
            var newImage = resizer.Resize(blob.Stream, new System.Drawing.Size(maxWidth, maxHeight));

            //TODO: smelly new filename logic
            var imageUri = new Uri(uri);
            var paths = imageUri.AbsolutePath.Split('/');
            var newBlobName = paths[paths.Length - 1].Replace(".jpg", string.Format("_{0}.jpg", Math.Max(maxWidth, maxHeight)));

            // save the blob
            await storage.CreateContainer("resized");
            var newUri = await storage.Upload("resized", newBlobName, "image/jpeg", newImage);

            // return the new URI
            return Request.CreateResponse(HttpStatusCode.OK, new { newUri });
        }

        private HttpResponseMessage ErrorResponse(Exception exception)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = exception.Message });
        }
    }

    public class ResizeTo
    {
        public string Uri { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
    }
}
