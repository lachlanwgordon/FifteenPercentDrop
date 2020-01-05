using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
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


        public ICommand WebsiteCommand => new AsyncCommand<string>(DoWebsiteCommandAsync);

        int clickCount;
        private async Task DoWebsiteCommandAsync(object obj)
        {
            clickCount++;
            await Task.Delay(500);
            Debug.WriteLine(clickCount);
            if (clickCount > 1)
            {
                await Task.Delay(500);
                clickCount = 0;
                return;
            }
            clickCount = 0;

            var url = obj as string;
            Debug.WriteLine("command");
            await Xamarin.Essentials.Browser.OpenAsync(url);
        }
    }
}
