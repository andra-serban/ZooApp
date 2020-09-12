using System;
using System.Collections.Generic;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using SampleXamarin.Adapters;
using Zoo.Models;
using ZooView.ViewModel;

namespace SampleXamarin
{
    [Activity(Label = "AnimalActivity")]
    public class AnimalActivity : ListActivity
    {
        public Individ individ;
        public const string mainUri = "https://zoo-webapp.azurewebsites.net/api/mainsapi/";
        public const string individUri = "https://zoo-webapp.azurewebsites.net/api/individsapi/";
        public const string animalUri = "https://zoo-webapp.azurewebsites.net/api/animalsapi/";
        public Main GetMains(string anchorId)
        {
            DataBase db = new DataBase();
            db.CreateDataBase();
            Main main = db.SelectQueryTableMain(anchorId);
            if (main == null)
            {
                HttpClient client = new HttpClient();
                string uri = mainUri;
                uri += anchorId;

                System.Threading.Tasks.Task<string> result = client.GetStringAsync(uri);
                main = JsonConvert.DeserializeObject<Main>(result.Result);
                db.InsertIntoTableMain(main);
            }
            
            return main;
        }

        public Individ GetIndivid(int id)
        {
            DataBase db = new DataBase();
            db.CreateDataBase();
            Individ individ = db.SelectQueryTableIndivid(id);
            if (individ == null)
            {
                HttpClient client = new HttpClient();
                string uri = individUri;
                uri += id;
                System.Threading.Tasks.Task<string> result = client.GetStringAsync(uri);

                //handling the answer
                individ = JsonConvert.DeserializeObject<Individ>(result.Result);
                db.InsertIntoTableIndivid(individ);
            }

            return individ;
        }
       
        public Animal GetAnimal(int id)
        {
            DataBase db = new DataBase();
            db.CreateDataBase();
            Animal animal = db.SelectQueryTableAnimal(id);
            if (animal == null)
            {
                HttpClient client = new HttpClient();
                string uri = animalUri;
                uri += id;
                System.Threading.Tasks.Task<string> result = client.GetStringAsync(uri);
                animal = JsonConvert.DeserializeObject<Animal>(result.Result);
                db.InsertIntoTableAnimal(animal);
            }

            return animal;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.animal_layout);

            string anchor = Intent.GetStringExtra("anchor");
            Main main = GetMains(anchor);
            individ = GetIndivid(main.Idindivid);
            Animal animal = GetAnimal(individ.Idanimal);

            AnimalAdapter adapter = new AnimalAdapter(this, new List<Animal>() {animal});
            ListView.Adapter = adapter;

            Button backButton = this.FindViewById<Button>(Resource.Id.BackButton);
            backButton.Click += this.OnBackClick;
            Button viewMoreButton = this.FindViewById<Button>(Resource.Id.ViewMoreButton);
            viewMoreButton.Click += this.OnViewMoreClick;
        }

        public void OnBackClick(object sender, EventArgs e)
        {
            Finish();
        }

        public void OnViewMoreClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(IndividActivity));
            intent.PutExtra("individ", JsonConvert.SerializeObject(individ));
            this.StartActivity(intent);
        }
    }
}