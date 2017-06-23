using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginTest.Views
{
    class DisplayCell : ViewCell
    {
        public DisplayCell()
        {
            var IdLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            IdLabel.SetBinding(Label.TextProperty, "Id");

            var DateLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            DateLabel.SetBinding(Label.TextProperty, "Date");

            var NoteLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            NoteLabel.SetBinding(Label.TextProperty, "Note");

            var line = new Label
            {
                Text = " ",
                BackgroundColor = Color.White,
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { /*IdLabel,*/ DateLabel, NoteLabel, line }
            };
            View = layout;
        }
    }
}
