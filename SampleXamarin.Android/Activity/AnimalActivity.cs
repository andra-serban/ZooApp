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
            var client = new HttpClient();
            string uri = "https://zoo-webapp.azurewebsites.net/api/mainsapi/";
            uri += anchorId;
           
            var result = client.GetStringAsync(uri);

            //handling the answer: if exc maybe not in db
            Main individ = JsonConvert.DeserializeObject<Main>(result.Result);

            //to do: make it work for main too

            //DataBase db = new DataBase();
            //db.createDataBase();

            //if (db.insertIntoTableMain(individ) is true)
            //{
            //    return db.selectQueryTableMain(anchorId);
            //}

            //if (db.selectQueryTableMain(anchorId) == null)
            //{
            //    throw new Exception();
            //}
            return individ;
        }

        public Individ GetIndivid(int id)
        { 
            DataBase db = new DataBase();
            db.createDataBase();

            if (db.selectQueryTableIndivid(id) == null)
            {
                var client = new HttpClient();
                var uri = "https://zoo-webapp.azurewebsites.net/api/individsapi/";
                uri += id;
                var result = client.GetStringAsync(uri);

                //handling the answer
                Individ individ = JsonConvert.DeserializeObject<Individ>(result.Result);
                db.insertIntoTableIndivid(individ);
            }

            return db.selectQueryTableIndivid(id);
        }
       
        public Animal GetAnimal(int id)
        {
            DataBase db = new DataBase();
            db.createDataBase();
            
            if (db.selectQueryTableAnimal(id) == null)
            {
                var client = new HttpClient();
                var uri = "https://zoo-webapp.azurewebsites.net/api/animalsapi/";
                uri += id;
                var result = client.GetStringAsync(uri);
                Animal animal = JsonConvert.DeserializeObject<Animal>(result.Result);
                db.insertIntoTableAnimal(animal);
            }

            return db.selectQueryTableAnimal(id);
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