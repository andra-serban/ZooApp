using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Zoo.Models;

namespace SampleXamarin.Adapters
{
    public class IndividInfoAdapter : BaseAdapter<IndividInfo>
    {
        List<IndividInfo> items;
        Activity context;
        public IndividInfoAdapter(Activity context, List<IndividInfo> items)
        : base()
        {
            this.context = context;
            this.items = items;
        }
        public override IndividInfo this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.individ_info, null);
            view.FindViewById<TextView>(Resource.Id.individName).Text = item.individ.Name;
            view.FindViewById<TextView>(Resource.Id.individBio).Text = item.individ.Bio;
            if (item.images.Image1 != null)
            {
                var imageBitmap1 = GetImageBitmapFromUrl(item.images.Image1);
                view.FindViewById<ImageView>(Resource.Id.Image1).SetImageBitmap(imageBitmap1);
            }
            if (item.images.Image2 != null)
            {
                var imageBitmap2 = GetImageBitmapFromUrl(item.images.Image2);
                view.FindViewById<ImageView>(Resource.Id.Image2).SetImageBitmap(imageBitmap2);
            }

            return view;
        }

        private Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
        {
            Android.Graphics.Bitmap imageBitmap = null;
            if (!(url == "null"))
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

            return imageBitmap;
        }
    }

}