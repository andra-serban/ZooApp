﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace SampleXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const double MIN_OPENGL_VERSION = 3.0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Check to see if the device supports SceneForm.
            if (!CheckIsSupportedDeviceOrFinish(this))
            {
                return;
            }

            // Set our view from the "main" layout resource
            this.SetContentView(Resource.Layout.activity_main);
            Button coarseRelocDemoButton = this.FindViewById<Button>(Resource.Id.coarseRelocDemoButton);
            coarseRelocDemoButton.Click += this.OnCoarseRelocDemoClick;
        }


        public void OnCoarseRelocDemoClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AzureSpatialAnchorsCoarseRelocActivity));
            this.StartActivity(intent);
        }

        public static bool CheckIsSupportedDeviceOrFinish(Activity activity)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.N)
            {
                Toast.MakeText(activity, "Sceneform requires Android N or later", ToastLength.Long).Show();

                activity.Finish();

                return false;
            }

            string openglString = ((ActivityManager)activity.GetSystemService(Context.ActivityService)).DeviceConfigurationInfo.GlEsVersion;

            if (double.Parse(openglString) < MIN_OPENGL_VERSION)
            {
                Toast.MakeText(activity, "Sceneform requires OpenGL ES 3.0 or later", ToastLength.Long).Show();

                return false;
            }

            return true;
        }
    }
}