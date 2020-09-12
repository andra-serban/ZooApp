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
    class AnchorTouchListener : Java.Lang.Object, IOnTouchListener
    {
        readonly Context Context;
        string identifier;

        public AnchorTouchListener(Context context, string identifier)
        {
            this.Context = context;
            this.identifier = identifier;
        }
        
        public bool OnTouch(HitTestResult p0, MotionEvent p1)
        {
            if (p1.Action == MotionEventActions.Down)
            {
                Intent intent = new Intent(Context, typeof(AnimalActivity));
                intent.PutExtra("anchor", identifier);
                Context.StartActivity(intent);
            }

            return true;
        }
    }
}