using LoginTest.Data;
using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabaseViewer : ContentPage
    {
        ListView lstView;
        public UserDatabaseController _UserQuery;
        public User _UserDB;
        public DatabaseViewer()
        {
            //SQL local database connection
            _UserDB = new User();
            _UserQuery = new UserDatabaseController();

            var createBtn = new Button { Text = "Create note" };
            lstView = new ListView { };
            lstView.ItemTemplate = new DataTemplate(typeof(DisplayCell));

            lstView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return; // ensures we ignore this handler when the selection is just being cleared 
                }
                var detail_Item = (User)e.SelectedItem;
                var detailPage = new EditPage();
                detailPage.BindingContext = detail_Item;
                await Navigation.PushAsync(detailPage);
                ((ListView)sender).SelectedItem = null;   // clears the 'selected' background
                                                          //InitializeComponent();
                                                          // BindingContext = new DatabaseViewerViewModel();
            };

        

            var mainlayout = new StackLayout { };
            mainlayout.Children.Add(createBtn);
            mainlayout.Children.Add(lstView);


            Content = mainlayout;
        }

        protected override void OnAppearing()
        {
            lstView.ItemsSource = _UserQuery.GetAllUsers();   //load the items to listview
            base.OnAppearing();
        }
    }
}

  