using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class MainViewModel
    {
        public List<Main> Mains { get; set; }
        public List<Main> GetMains()
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/mainsapi";
            var result = client.GetStringAsync(uri);

            //handling the answer
            List<Main> individs = JsonConvert.DeserializeObject<List<Main>>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            foreach (var individ in individs)
            {
                db.insertIntoTableMain(individ);
            }
            return db.selectTableMain();
        }
        public MainViewModel()
        {
            Mains = GetMains();
        }
    }
}
