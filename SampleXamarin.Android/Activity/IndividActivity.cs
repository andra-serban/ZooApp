using System;
using System.Collections.Generic;
using System.Net.Http;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using SampleXamarin.Adapters;
using SampleXamarin.Constants;
using Zoo.Models;
using ZooView.ViewModel;

namespace SampleXamarin
{
    [Activity(Label = "IndividActivity")]
    public class IndividActivity : ListActivity
    {
        private Animal animal;

        public Main GetMains(string anchorId, DataBase db, HttpClient client)
        {
            Main main = db.SelectQueryTableMain(anchorId);
            if (main == null)
            {
                System.Threading.Tasks.Task<string> result = client.GetStringAsync(WebConstants.mainUri + anchorId);
                main = JsonConvert.DeserializeObject<Main>(result.Result);
                db.InsertIntoTableMain(main);
            }

            return main;
        }

        public Individ GetIndivid(int id, DataBase db, HttpClient client)
        {
            Individ individ = db.SelectQueryTableIndivid(id);
            if (individ == null)
            {
                System.Threading.Tasks.Task<string> result = client.GetStringAsync(WebConstants.individUri + id);
                individ = JsonConvert.DeserializeObject<Individ>(result.Result);
                db.InsertIntoTableIndivid(individ);
            }

            return individ;
        }

        public Animal GetAnimal(int id, DataBase db, HttpClient client)
        {
            Animal animal = db.SelectQueryTableAnimal(id);
            if (animal == null)
            {
                System.Threading.Tasks.Task<string> result = client.GetStringAsync(WebConstants.animalUri + id);
                animal = JsonConvert.DeserializeObject<Animal>(result.Result);
                db.InsertIntoTableAnimal(animal);
            }

            return animal;
        }

        public IndividImages GetImages(int id, DataBase db, HttpClient client)
        {
            IndividImages images = db.SelectQueryTableIndividImages(id);
            if (images == null)
            {
                System.Threading.Tasks.Task<string> result = client.GetStringAsync(WebConstants.imagesUri + id);
                images = JsonConvert.DeserializeObject<IndividImages>(result.Result);
                db.InsertIntoTableIndividImages(images);
            }

            return images;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //this.SetContentView(Resource.Layout.individ_info);
            string anchor = Intent.GetStringExtra("anchor");

            DataBase db = new DataBase();
            db.CreateDataBase();
            HttpClient client = new HttpClient();

            Main main = GetMains(anchor, db, client);
            Individ individ = GetIndivid(main.Idindivid, db, client);
            animal = GetAnimal(individ.Idanimal, db, client);
            IndividImages individImages = GetImages(individ.Id, db, client);

            IndividInfo individInfo = new IndividInfo(individ, individImages);
            IndividInfoAdapter adapter = new IndividInfoAdapter(this, new List<IndividInfo>() {individInfo});
            ListView.FindViewById(Resource.Id.ListView);
            ListView.Adapter = adapter;

            //Button backButton = this.FindViewById<Button>(Resource.Id.BackButton);
            //backButton.Click += this.OnBackClick;
            //Button viewMoreButton = this.FindViewById<Button>(Resource.Id.ViewButton);
            //viewMoreButton.Click += this.OnViewClick;
        }

        public void OnBackClick(object sender, EventArgs e)
        {
            Finish();
        }

        public void OnViewClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AnimalActivity));
            intent.PutExtra("animal", JsonConvert.SerializeObject(animal));
            this.StartActivity(intent);
        }
    }
}