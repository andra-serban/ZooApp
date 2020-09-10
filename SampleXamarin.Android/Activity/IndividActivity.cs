using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Newtonsoft.Json;
using SampleXamarin.Adapters;
using Zoo.Models;
using ZooView.ViewModel;

namespace SampleXamarin
{
    [Activity(Label = "IndividActivity")]
    public class IndividActivity : ListActivity
    {
        public IndividImages GetImages(int id)
        {
            DataBase db = new DataBase();
            db.CreateDataBase();
            IndividImages images = db.SelectQueryTableIndividImages(id);
            if (images == null)
            {
                var client = new HttpClient();
                var uri = "https://zoo-webapp.azurewebsites.net/api/IndividImagesApi/";
                uri += id;
                var result = client.GetStringAsync(uri);
                images = JsonConvert.DeserializeObject<IndividImages>(result.Result);
                db.InsertIntoTableIndividImages(images);
            }

            return images;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.individ_info);

            Individ individ = JsonConvert.DeserializeObject<Individ>(Intent.GetStringExtra("individ"));
            var individImages = GetImages(individ.Id);
            IndividInfo individInfo = new IndividInfo(individ, individImages);
            IndividInfoAdapter adapter = new IndividInfoAdapter(this, new List<IndividInfo>() {individInfo});
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