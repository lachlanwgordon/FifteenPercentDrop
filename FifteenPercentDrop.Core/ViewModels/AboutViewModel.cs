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


        public ICommand WebsiteCommand => new FifteenPercentDrop.Core.Helpers.SafeCommand<string>(DoWebsiteCommandAsync);

        private void CatchException(Exception ex)
        {
            Debug.WriteLine($"Error in Vm {ex}");
        }

        private async Task DoWebsiteCommandAsync(object obj)
        {
            throw new NotImplementedException();
            var url = obj as string;
            Debug.WriteLine("command");
            await Xamarin.Essentials.Browser.OpenAsync(url);
        }
    }
}
