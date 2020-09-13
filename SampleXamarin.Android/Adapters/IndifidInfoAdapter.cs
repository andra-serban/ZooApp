using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace SampleXamarin.Adapters
{
    public class IndividInfoAdapter : BaseAdapter<IndividInfo>
    {
        private readonly List<IndividInfo> items;
        private readonly Activity context;

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
            IndividInfo item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.individ_info, null);
            view.FindViewById<TextView>(Resource.Id.individName).Text = item.individ.Name;
            view.FindViewById<TextView>(Resource.Id.individBio).Text = item.individ.Bio;
            if (item.images.Image1 != null)
            {
                Bitmap imageBitmap1 = BitmapImage.GetImageBitmapFromUrl(item.images.Image1);
                view.FindViewById<ImageView>(Resource.Id.Image1).SetImageBitmap(imageBitmap1);
            }
            if (item.images.Image2 != null)
            {
                Bitmap imageBitmap2 = BitmapImage.GetImageBitmapFromUrl(item.images.Image2);
                view.FindViewById<ImageView>(Resource.Id.Image2).SetImageBitmap(imageBitmap2);
            }

            return view;
        }

    }

}