using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LoginTest.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        
        public string Username { get; set; }
        public string Password { get; set; }

        public string FlaskNumber { get; set; }

      //  public int Id { get; set; } 
        public User() { }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
            {
                if (App.UserDatabase.VerifyUser(this))
                    return true;
                else
                {
                    Debug.WriteLine("User: ");
                    Debug.WriteLine(this.Username.ToString());
                    Debug.WriteLine("Password: ");
                    Debug.WriteLine(this.Password.ToString());

                    return false;
                }
            }
            else
                return false;
        }
    }
}
