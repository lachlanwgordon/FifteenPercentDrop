using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using FifteenPercentDrop.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace FifteenPercentDrop.Core.ViewModels
{
    public class AboutViewModel
    {
        public ObservableRangeCollection<string> Entries = new ObservableRangeCollection<string> { "cell 1", "number 2" };
        public AboutViewModel()
        {
        }

        public bool AnalyticsEnabled
        {
            get => Xamarin.Essentials.Preferences.Get(PreferencesKeys.Analytics, true);
            set => Xamarin.Essentials.Preferences.Set(PreferencesKeys.Analytics, value);
        }

        public ICommand WebsiteCommand => new Helpers.SafeCommand<string>(DoWebsiteCommandAsync);

        private async Task DoWebsiteCommandAsync(object obj)
        {
            var url = obj as string;
            Debug.WriteLine("command");
            await Xamarin.Essentials.Browser.OpenAsync(url);
        }

    }
}
