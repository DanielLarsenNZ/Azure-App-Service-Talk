using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using ImageViewer.Web.Models;
using Scale.Storage.Blob;

namespace ImageViewer.Web.Services
{
    public class ImageListService
    {
        public async Task<IEnumerable<Image>> List()
        {
            var storage = new AzureBlobStorage(System.Configuration.ConfigurationManager.AppSettings);
            var blobs = await storage.List("resized", false);
            return blobs.Select(b => new Image { SmallImageUrl = b.Uri, BigImageUri = b.Uri.Replace("/resized/", "/images/") });
        }
    }
}