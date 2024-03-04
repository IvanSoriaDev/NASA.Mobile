using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using NASA.Mobile.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Provider;
using Java.IO;
using Android.Graphics;
using Application = Android.App.Application;

namespace NASA.Mobile.Platforms
{
    public class ImageService : IImageService
    {
        public async Task<bool> DownloadAndSaveImageAsync(string imageUrl)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            var httpClient = new System.Net.Http.HttpClient
            {
                Timeout = System.TimeSpan.FromSeconds(360)
            };

            var imageData = await httpClient.GetByteArrayAsync(imageUrl);
            var bitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                var contentValues = new Android.Content.ContentValues();
                contentValues.Put(Android.Provider.MediaStore.MediaColumns.DisplayName, "downloadedImage.jpg");
                contentValues.Put(Android.Provider.MediaStore.MediaColumns.MimeType, "image/jpeg");
                contentValues.Put(Android.Provider.MediaStore.MediaColumns.RelativePath, Android.OS.Environment.DirectoryDownloads + "/YourAppName");

                var resolver = Android.App.Application.Context.ContentResolver;
                var uri = resolver.Insert(Android.Provider.MediaStore.Downloads.ExternalContentUri, contentValues);

                using (var stream = resolver.OpenOutputStream(uri))
                {
                    bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
                }

                return true;
            }
            else
            {
                var picturesDirectory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
                var imageFile = new Java.IO.File(picturesDirectory, "downloadedImage.jpg");

                using (var fileOutputStream = new Java.IO.FileOutputStream(imageFile))
                using (var netStream = new System.IO.BufferedStream(System.IO.Stream.Synchronized(new Android.Runtime.OutputStreamInvoker(fileOutputStream))))
                {
                    bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, netStream);
                    netStream.Flush(); // Ensure all data is written to the underlying fileOutputStream
                }

                return true;
            }
        }
    }
}
