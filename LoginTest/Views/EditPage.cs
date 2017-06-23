using LoginTest.Data;
using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginTest.Views
{
    public class EditPage : ContentPage
    {
        public UserDatabaseController _UserQuery;
        public User _UserDB;
        private DateTime _DateTime;
        public string primary;
        public EditPage()
        {
            //SQL local database connection
            _UserDB = new User();
            _UserQuery = new UserDatabaseController();

            var UsernameEntry = new Entry { };
            UsernameEntry.SetBinding(Entry.TextProperty, "Username");
            UsernameEntry.IsVisible = false;

            var PasswordEntry = new Entry { };
            PasswordEntry.SetBinding(Entry.TextProperty, "Password");


            var updateButton = new Button { Text = "UPDATE" };
            var deleteButton = new Button { Text = "DELETE" };
            var cancelButton = new Button { Text = "CANCEL" };

            //Update the selected data
            updateButton.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    _DateTime = DateTime.Now;
                    UpdateData(  UsernameEntry.ToString(), PasswordEntry.ToString());
                    DisplayAlert("Alert", "Updated Succesfully.", "OK");
                    Navigation.PushAsync(new DatabaseViewer());
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    DisplayAlert("Sorry...", "Something went wrong. Try after sometime.", "OK");
                }
            };

            //Delete selected data
            deleteButton.Clicked += (object sender, EventArgs e) =>
            {
                try
                { 
                    _UserQuery.DeleteUser(UsernameEntry.ToString());
                    DisplayAlert("Alert", "Deleted Succesfully.", "OK");
                    Navigation.PushAsync(new DatabaseViewer());
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    DisplayAlert("Sorry...", "Something went wrong. Try after sometime.", "OK");
                }
            };


            cancelButton.Clicked += (sender, e) =>
            {
                var NoteItem = (User)BindingContext;
                this.Navigation.PopAsync();
            };

            var btnStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children ={
                    updateButton,deleteButton,cancelButton
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20),
                Children = {
                    UsernameEntry,PasswordEntry,btnStack

                }
            };

        }

        public void UpdateData(string Username, string Password)
        { 
            _UserDB.Username = Username;
            _UserDB.Password = Password;
        }
    }
}
