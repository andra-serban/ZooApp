using SQLite;
using System.Collections.Generic;
using System.Linq;
using Zoo19._07.Models;

namespace ZooView.ViewModel
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDataBase()
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

        public bool insertIntoTableAnimal(Animal animal)
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


        public bool insertIntoTableIndivid(Individ individ)
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

        public bool insertIntoTableMainIstoric(MainHistory individ)
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

        public bool insertIntoTableMain(Main individ)
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

        public bool insertIntoTablePozaIndivid(IndividImages individ)
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

        public bool insertIntoTableZooInfo(ZooInfo individ)
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


        public List<Animal> selectTableAnimal()
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

        public List<Individ> selectTableIndivid()
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

        public List<MainHistory> selectTableMainIstoric()
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

        public List<Main> selectTableMain()
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

        public List<IndividImages> selectTablePozaIndivid()
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

        public List<ZooInfo> selectTableZooInfo()
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


        public bool deleteTableAnimal(Animal animal)
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

        public Animal selectQueryTableAnimal(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Query<Animal>("SELECT * FROM Animal Where Id=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public Individ selectQueryTableIndivid(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Query<Individ>("SELECT * FROM Individ Where Id=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public Main selectQueryTableMain(string Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Query<Main>("SELECT * FROM Main Where Ancora=?", Id).First();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }


    }
}