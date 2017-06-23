using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        void RegistrationProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_UsernameRegistered.Text, Entry_PasswordRegistered.Text);
           // if (user.CheckInformation())
           // {
                DisplayAlert("Registration", "Registration Success", "Ok");
                App.UserDatabase.SaveUser(user);
          //  }
          //  else
          //  {
          //      DisplayAlert("Registration", "Registration Unsucessful", "Ok");
          //  }
        }
    }
}