using SQLite;
using System;
using System.Linq;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class DataBase
    {
        readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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

        public Object SelectQueryTable(int Id, string selectionQuery)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBase));
                return connection.Query<Object>(selectionQuery, Id).First();
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public Object SelectQueryTable(string Id, string selectionQuery)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBase));
                return connection.Query<Object>(selectionQuery, Id).First();
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
    }
}