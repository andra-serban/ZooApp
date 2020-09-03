using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class IndividViewModel
    {
        public List<Individ> Individs { get; set; }
        public List<Individ> GetIndivids()
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/individsapi";
            var result = client.GetStringAsync(uri);

            //handling the answer
            List<Individ> individs = JsonConvert.DeserializeObject<List<Individ>>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            foreach (var individ in individs)
            {
                db.insertIntoTableIndivid(individ);
            }
            return db.selectTableIndivid();
        }
        public IndividViewModel()
        {
            Individs = GetIndivids();
        }
    }
}
