using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class ZooInfoViewModel
    {
        public List<ZooInfo> ZooInfo { get; set; }
        public List<ZooInfo> GetAnimals()
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/zooinfoesapi";
            var result = client.GetStringAsync(uri);

            //handling the answer
            List<ZooInfo> animals = JsonConvert.DeserializeObject<List<ZooInfo>>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            foreach (var animal in animals)
            {
                db.insertIntoTableZooInfo(animal);
            }
            return db.selectTableZooInfo();
        }
        public ZooInfoViewModel()
        {
            ZooInfo = GetAnimals();
        }
    }
}
