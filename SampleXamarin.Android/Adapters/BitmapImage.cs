using System.Net;
using Android.Graphics;

namespace SampleXamarin.Adapters
{
    static class BitmapImage
    {
        static public Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            if (!(url == "null"))
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

            return imageBitmap;
        }
    }
}