using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FifteenPercentDrop.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

namespace FifteenPercentDrop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Xamarin.Forms.Device.SetFlags(new[] {"StateTriggers_Experimental"});

            //All this for an easter egg?!
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
            var analytics = Xamarin.Essentials.Preferences.Get("Analytics", true);
            if (analytics)
            {
                var iosKey = FifteenPercentDrop.Core.Helpers.SharedSecrets.AppCenteriOS;
                var droidKey = FifteenPercentDrop.Core.Helpers.SharedSecrets.AppCenterDroid;
                AppCenter.Start(iosKey,
                   typeof(Analytics), typeof(Crashes));

                AppCenter.Start($"android={droidKey};" +
                  $"ios={iosKey}",
                  typeof(Analytics), typeof(Crashes));
            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
