using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class MainIstoricViewModel
    {
        public List<MainIstoric> Individs { get; set; }
        public List<MainIstoric> GetIndivids()
        {
            var client = new HttpClient();
            var uri = "https://zoo190720200814131500.azurewebsites.net/api/mainistoricapi";
            var result = client.GetStringAsync(uri);

            //handling the answer
            List<MainIstoric> individs = JsonConvert.DeserializeObject<List<MainIstoric>>(result.Result);

            DataBase db = new DataBase();
            db.createDataBase();
            foreach (var individ in individs)
            {
                db.insertIntoTableMainIstoric(individ);
            }
            return db.selectTableMainIstoric();
        }
        public MainIstoricViewModel()
        {
            Individs = GetIndivids();
        }
    }
}
