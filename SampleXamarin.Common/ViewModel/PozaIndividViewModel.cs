using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class PozaIndividViewModel
    {
        public List<PozaIndivid> PozaIndivid { get; set; }
        public List<PozaIndivid> GetAnimals()
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/pozaindividsapi";
            var result = client.GetStringAsync(uri);

            //handling the answer
            List<PozaIndivid> animals = JsonConvert.DeserializeObject<List<PozaIndivid>>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            foreach (var animal in animals)
            {
                db.insertIntoTablePozaIndivid(animal);
            }
            return db.selectTablePozaIndivid();
        }
        public PozaIndividViewModel()
        {
            PozaIndivid = GetAnimals();
        }
    }
}
