using SQLite;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models;

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
                    connection.CreateTable<MainIstoric>();
                    connection.CreateTable<Main>();
                    connection.CreateTable<ZooInfo>();
                    connection.CreateTable<PozaIndivid>();
                    return true;
                }
            }
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool insertIntoTableMainIstoric(MainIstoric individ)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(individ);
                    return true;
                }
            }
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool insertIntoTablePozaIndivid(PozaIndivid individ)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    connection.Insert(individ);
                    return true;
                }
            }
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public List<MainIstoric> selectTableMainIstoric()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<MainIstoric>().ToList();

                }
            }
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public List<PozaIndivid> selectTablePozaIndivid()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Animals.db")))
                {
                    return connection.Table<PozaIndivid>().ToList();

                }
            }
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
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
            catch (SQLiteException ex)
            {
                return null;
            }
        }


    }
}