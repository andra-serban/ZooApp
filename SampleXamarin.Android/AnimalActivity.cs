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
using Zoo19._07.Models;
using ZooView.ViewModel;

namespace SampleXamarin
{
    [Activity(Label = "AnimalActivity")]
    public class AnimalActivity : ListActivity
    {
        public Main GetMains(string anchorId)
        {
            var client = new HttpClient();
            string uri = "https://zoo190720200814131500.azurewebsites.net/api/mainsapi/";
            uri += anchorId;
           
            var result = client.GetStringAsync(uri);

            //handling the answer: if exc maybe not in db
            Main individ = JsonConvert.DeserializeObject<Main>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            db.insertIntoTableMain(individ);

            return db.selectQueryTableMain(anchorId);
        }

        public Individ GetIndivid(int id)
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/individsapi/";
            uri += id;
            var result = client.GetStringAsync(uri);

            //handling the answer
            Individ individ = JsonConvert.DeserializeObject<Individ>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            db.insertIntoTableIndivid(individ);

            return db.selectQueryTableIndivid(id);
        }
       
        public Animal GetAnimal(int id)
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/animalsapi";
            uri += "/" + id;
            var result = client.GetStringAsync(uri);

            Animal animal = JsonConvert.DeserializeObject<Animal>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            db.insertIntoTableAnimal(animal);
           
            return db.selectQueryTableAnimal(id);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var anchor = Intent.GetStringExtra("anchor");

            var main = GetMains(anchor);
            var individ = GetIndivid(main.Idindivid);
            var animal = GetAnimal(individ.Idanimal);

            AnimalAdapter adapter = new AnimalAdapter(this, new List<Animal>() { animal });
            ListView.Adapter = adapter;
        }

    }
}