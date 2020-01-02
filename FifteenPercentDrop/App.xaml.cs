using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FifteenPercentDrop.Views;

namespace FifteenPercentDrop
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var rainbows = Xamarin.Essentials.Preferences.Get("Rainbows", false);
            if (rainbows)
            {

                var DebugStyle = new Style(typeof(ContentPage))
                {
                    ApplyToDerivedTypes = true,
                    Setters =
                    {
                        new Setter
                        {
                            Property = Xamarin.Forms.DebugRainbows.DebugRainbow.ShowColorsProperty,
                            Value = true
                        }
                    }
                };

                Current.Resources.Add(DebugStyle);
            }
            MainPage = new AppShell(); 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
