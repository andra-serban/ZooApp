using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class AnimalViewModel
    {
        public List<Animal> Animals { get; set; }
        public List<Animal> GetAnimals()
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/animalsapi";
            var result = client.GetStringAsync(uri);

            //handling the answer
            List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            foreach (var animal in animals)
            {
                db.insertIntoTableAnimal(animal);
            }
            return db.selectTableAnimal();
        }
        public AnimalViewModel()
        {
            Animals = GetAnimals();
        }
    }
}
