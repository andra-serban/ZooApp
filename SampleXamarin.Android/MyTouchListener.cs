using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.AR.Sceneform;
using static Google.AR.Sceneform.Node;

namespace SampleXamarin
{
    class MyTouchListener : Java.Lang.Object, IOnTouchListener
    {

        Context context;
        string identifier;
        public MyTouchListener(Context context, string identifier)
        {
            this.context = context;
            this.identifier = identifier;
        }
        public bool OnTouch(HitTestResult p0, MotionEvent p1)
        {
            //Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            //AlertDialog alert = dialog.Create();
            //alert.SetTitle("Alert");
            //alert.SetMessage("Activity1 opened");
            //alert.SetButton("OK", (c, ev) =>
            //{

            //});
            //alert.Show();
            if (p1.Action == MotionEventActions.Down)
            {
                Intent intent = new Intent(context, typeof(AnimalActivity));
                intent.PutExtra("anchor", identifier);
                context.StartActivity(intent);
            }
            return true;
        }
    }
}