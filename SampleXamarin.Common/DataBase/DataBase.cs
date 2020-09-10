using SQLite;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models;

namespace ZooView.ViewModel
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.CreateTable<Animal>();
                    connection.CreateTable<Individ>();
                    connection.CreateTable<MainHistory>();
                    connection.CreateTable<Main>();
                    connection.CreateTable<ZooInfo>();
                    connection.CreateTable<IndividImages>();
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool InsertIntoTableAnimal(Animal animal)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(animal);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }


        public bool InsertIntoTableIndivid(Individ individ)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(individ);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool InsertIntoTableMainIstoric(MainHistory individ)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(individ);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool InsertIntoTableMain(Main individ)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(individ);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool InsertIntoTablePozaIndivid(IndividImages individ)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(individ);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool InsertIntoTableZooInfo(ZooInfo individ)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(individ);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }


        public List<Animal> SelectTableAnimal()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<Animal>().ToList();

                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public List<Individ> SelectTableIndivid()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<Individ>().ToList();

                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public List<MainHistory> SelectTableMainIstoric()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<MainHistory>().ToList();

                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public List<Main> SelectTableMain()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<Main>().ToList();

                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public List<IndividImages> SelectTablePozaIndivid()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<IndividImages>().ToList();

                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public List<ZooInfo> SelectTableZooInfo()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<ZooInfo>().ToList();

                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }


        public bool DeleteTableAnimal(Animal animal)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Delete(animal);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public Animal SelectQueryTableAnimal(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
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
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
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
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Query<Main>("SELECT EXISTS * FROM Main Where Ancora=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }


    }
}