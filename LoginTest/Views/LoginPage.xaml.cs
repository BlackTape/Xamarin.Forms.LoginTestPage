using LoginTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
namespace LoginTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        ListView tView;

        public LoginPage()
        {
            InitializeComponent();
            Entry_Username.Text = "";
            Entry_Password.Text = "";
            Init();

        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
           // App.UserDatabase.RetrieveUserRecord(user);
               PrintTable();
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "Ok");
             
                
               // App.UserDatabase.SaveUser(user);
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, Wrong Username or Password", "Ok");
            }
        }

         

        void PrintTable()
        {
            IList ListOfUsers;

            ListOfUsers = App.UserDatabase.GetAllUsers();
            Debug.WriteLine("List is as follows");
            foreach (var IUserList in ListOfUsers)
            {               
                Debug.WriteLine(IUserList); 
                
            }                      
        }
    }
}