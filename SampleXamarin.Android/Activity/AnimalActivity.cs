using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using SampleXamarin.Adapters;
using Zoo.Models;

namespace SampleXamarin
{
    [Activity(Label = "AnimalActivity")]
    public class AnimalActivity : ListActivity
    {   
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.animal_layout);

            string anchor = Intent.GetStringExtra("anchor");
            Animal animal = JsonConvert.DeserializeObject<Animal>(Intent.GetStringExtra("animal"));
            AnimalAdapter adapter = new AnimalAdapter(this, new List<Animal>() { animal });
            ListView.Adapter = adapter;

            Button backButton = this.FindViewById<Button>(Resource.Id.BackButton);
            backButton.Click += this.OnBackClick;
        }

        public void OnBackClick(object sender, EventArgs e)
        {
            Finish();
        }
    }
}