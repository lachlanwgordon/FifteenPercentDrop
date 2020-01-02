using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
                await Task.Delay(500);
                clickCount = 0;
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
            DisplayAlert("You found the Debug Rainbow!", "Yay, Thanks Steven Thewissen", "Okay");
        }


    }
}
