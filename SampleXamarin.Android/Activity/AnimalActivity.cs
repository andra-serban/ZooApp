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
    [Activity(Label = "AnimalActivity")]
    public class AnimalActivity : ListActivity
    {
        public Main GetMains(string anchorId)
        {
            DataBase db = new DataBase();
            db.createDataBase();
            Main main = db.selectQueryTableMain(anchorId);
            if (main == null)
            {
                var client = new HttpClient();
                string uri = "https://zoo-webapp.azurewebsites.net/api/mainsapi/";
                uri += anchorId;

                var result = client.GetStringAsync(uri);
                main = JsonConvert.DeserializeObject<Main>(result.Result);
                db.insertIntoTableMain(main);
            }
            
            return main;
        }

        public Individ GetIndivid(int id)
        {
            DataBase db = new DataBase();
            db.createDataBase();
            Individ individ = db.selectQueryTableIndivid(id);
            if (individ == null)
            {
                var client = new HttpClient();
                var uri = "https://zoo-webapp.azurewebsites.net/api/individsapi/";
                uri += id;
                var result = client.GetStringAsync(uri);

                //handling the answer
                individ = JsonConvert.DeserializeObject<Individ>(result.Result);
                db.insertIntoTableIndivid(individ);
            }

            return individ;
        }
       
        public Animal GetAnimal(int id)
        {
            DataBase db = new DataBase();
            db.createDataBase();
            Animal animal = db.selectQueryTableAnimal(id);
            if (animal == null)
            {
                var client = new HttpClient();
                var uri = "https://zoo-webapp.azurewebsites.net/api/animalsapi/";
                uri += id;
                var result = client.GetStringAsync(uri);
                animal = JsonConvert.DeserializeObject<Animal>(result.Result);
                db.insertIntoTableAnimal(animal);
            }

            return animal;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.AnimalLayout);

            var anchor = Intent.GetStringExtra("anchor");
            var main = GetMains(anchor);
            var individ = GetIndivid(main.Idindivid);
            var animal = GetAnimal(individ.Idanimal);

            AnimalAdapter adapter = new AnimalAdapter(this, new List<Animal>() { animal });
            ListView.Adapter = adapter;
            Button basicDemoButton = this.FindViewById<Button>(Resource.Id.button1);
            basicDemoButton.Click += this.OnBackClick;
        }

        public void OnBackClick(object sender, EventArgs e)
        {
            Finish();
        }
    }
}