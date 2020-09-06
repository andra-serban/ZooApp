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
    public class AnimalAdapter : BaseAdapter<Animal>
    {
        List<Animal> items;
        Activity context;
        public AnimalAdapter(Activity context, List<Animal> items)
        : base()
        {
            this.context = context;
            this.items = items;
        }
        public override Animal this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.AnimalLayout, null);

            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Specie;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.CommonName;
            view.FindViewById<TextView>(Resource.Id.Text3).Text = item.MaxWeight.ToString() + " kg";

            var imageBitmap = GetImageBitmapFromUrl(item.Image);
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(imageBitmap);
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