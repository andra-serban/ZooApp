using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Zoo.Models;

namespace SampleXamarin.Adapters
{
    public class AnimalAdapter : BaseAdapter<Animal>
    {
        private readonly List<Animal> items;
        private readonly Activity context;
        public AnimalAdapter(Activity activityContext, List<Animal> items)
        : base()
        {
            this.context = activityContext;
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
            Animal item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.animal_layout, null);

            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Specie;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.CommonName;
            view.FindViewById<TextView>(Resource.Id.Text3).Text = item.MaxWeight.ToString() + " kg";
            Android.Graphics.Bitmap imageBitmap = BitmapImage.GetImageBitmapFromUrl(item.Image);
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(imageBitmap);

            return view;
        }
    }
}