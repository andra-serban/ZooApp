using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class DataBase
    {
        readonly string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public const string dataBase = "Animals.db";

        public async System.Threading.Tasks.Task<bool> CreateDataBaseAsync()
        {
            try
            {
                SQLiteAsyncConnection connection = new SQLiteAsyncConnection(System.IO.Path.Combine(folder, dataBase));                {
  
                    foreach(Type tableType in new Type[] { typeof(Animal),
                        typeof(Individ), 
                        typeof(MainHistory), 
                        typeof(Main), 
                        typeof(ZooInfo), 
                        typeof(IndividImages)})
                    {
                            await connection.CreateTablesAsync(CreateFlags.None, tableType).ConfigureAwait(false);
                    }
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool InsertIntoTable(Object objectToBeInserted)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBase));
                connection.Insert(objectToBeInserted);
                return true;
                
            }
            catch (SQLiteException)
            {
                return false;
            }

        }

        public bool InsertIntoTableAnimal(Animal animal)
        {
            return InsertIntoTable(animal);
        }


        public bool InsertIntoTableIndivid(Individ individ)
        {
            return InsertIntoTable(individ);
        }

        public bool InsertIntoTableMainIstoric(MainHistory mainHistory)
        {
            return InsertIntoTable(mainHistory);
        }

        public bool InsertIntoTableMain(Main main)
        {
            return InsertIntoTable(main);
        }

        public bool InsertIntoTableIndividImages(IndividImages individImages)
        {
            return InsertIntoTable(individImages);
        }

        public Animal SelectQueryTableAnimal(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBase)))
                {
                    return connection.Query<Animal>("SELECT  EXISTS * FROM Animal Where Id=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public Individ SelectQueryTableIndivid(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBase)))
                {
                    return connection.Query<Individ>("SELECT EXISTS * FROM Individ Where Id=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public Main SelectQueryTableMain(string Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBase)))
                {
                    return connection.Query<Main>("SELECT EXISTS * FROM Main Where Ancora=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public IndividImages SelectQueryTableIndividImages(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBase)))
                {
                    return connection.Query<IndividImages>("SELECT EXISTS * FROM IndividImages Where Idindivid=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
    }
}