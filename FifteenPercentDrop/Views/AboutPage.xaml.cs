using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FifteenPercentDrop.Services;
using Xamarin.Forms;

namespace FifteenPercentDrop.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        void TextCell_Tapped(object sender, EventArgs e)
        {
        }


        int clickCount;
        async void DebugRainbows(object sender, EventArgs e)
        {
            clickCount++;
            if(clickCount < 2)
            {
                var cell = sender as TextCell;
                VM.WebsiteCommand.Execute(cell.CommandParameter);
                return;
            }
            clickCount = 0;

            var rainbows = Xamarin.Essentials.Preferences.Get("Rainbows", false);
            Xamarin.Essentials.Preferences.Set("Rainbows", !rainbows);

            if (Application.Current.Resources.ContainsKey("Xamarin.Forms.ContentPage"))
                Application.Current.Resources.Remove("Xamarin.Forms.ContentPage");

            var DebugStyle = new Style(typeof(ContentPage))
            {
                ApplyToDerivedTypes = true,
                Setters =
                    {
                        new Setter
                        {
                            Property = Xamarin.Forms.DebugRainbows.DebugRainbow.ShowColorsProperty,
                            Value = !rainbows
                        }
                    }
            };

            Application.Current.Resources.Add(DebugStyle);
            await DisplayAlert("You found the Debug Rainbow!", "Yay, Thanks Steven Thewissen. \nPlease force quit the app and start again to enjoy this feature.", "Okay");
        }

        ILogger Logger = new Logger();
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Logger.Log("About Page Opened");
        }
    }
}
