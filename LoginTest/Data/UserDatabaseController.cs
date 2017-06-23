using LoginTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections;

namespace LoginTest.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();
        public bool _SomeoneIsLoggedIn;
        public string CurrentUser;
        public string Password;
        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
          //  var Idatabase = new Token 
            database.CreateTable<User>( );
            _SomeoneIsLoggedIn = false;
        }

        public User GetUser()
        {
            lock(locker)
            {
                if(database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().First();
                }               
            }
        }

       
        public void RetrieveUserRecord(User user)
        {
            User CheckedUser = database.Table<User>().Where(i => i.Username == user.Username).First();
            Debug.WriteLine("Retrieved ");
            Debug.WriteLine(CheckedUser.Username);
            Debug.WriteLine(CheckedUser.Password);
            string dbList = "";
        //    database.Query(database.Table<User>(), dbList[], null, null, null, null, null);
        }
             
        public int SaveUser(User user)
        {
            lock(locker)
            {
                if(user.Username !="" && user.Password!="")
                {
                      database.InsertOrReplace(user);
                    // user.Id = database.Insert(user);
                    //user.Id=database.Update(user);
                    
                    Debug.WriteLine("Save username ");
                    Debug.WriteLine(user.Username.ToString());
                    Debug.WriteLine(user.Password.ToString());
                    //  Debug.WriteLine(user.Id.ToString());

                    return 0;// user.Id;
                }
                else
                {
                    // return database.Insert(user);
                    Debug.WriteLine("Insert or replace ");
                    Debug.WriteLine(user.Username.ToString());
                    Debug.WriteLine(user.Password.ToString());

                    return database.InsertOrReplace(user);
                }
            }
        }


        public bool VerifyUser(User user)
        { 
            User curr;
            curr = database.Table<User>().FirstOrDefault(x => x.Username == user.Username);
            if (curr != null)
            {
                Debug.WriteLine("Found Records: ");
                Debug.WriteLine(curr.Username.ToString());
                Debug.WriteLine(curr.Password.ToString());
           

            if (database.Table<User>().Count() == 0)
            {
                return false;
            }
            else
            {
                // if (database.Table<User>().Equals(user))
                if(curr.Username== user.Username && curr.Password == user.Password)
                {
                    Debug.WriteLine("Bingo Current: ");

                    Debug.WriteLine(user.Username.ToString());
                    Debug.WriteLine(user.Password.ToString());
                    _SomeoneIsLoggedIn = true;
                        CurrentUser = user.Username.ToString();
                        Password = user.Password.ToString();
                    return true;
                }
                else
                {
                    Debug.WriteLine("Current: False = ");
                    _SomeoneIsLoggedIn = false;
                    Debug.WriteLine(user.Username.ToString());
                    Debug.WriteLine(user.Password.ToString());
                    return false;
                }
            }           
            }
            else
            {
                return false;
            }
        }


        public int DeleteUser(string id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }

        public List<User> GetAllUsers( )
        {
            //return database.Query<User>("Select * From [User]");
            return (from i in database.Table<User>() select i).ToList();
        }
              

    }
}
