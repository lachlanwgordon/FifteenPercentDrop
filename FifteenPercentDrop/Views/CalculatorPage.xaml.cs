using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FifteenPercentDrop.Services;
using Xamarin.Forms;
using Xamarin.Forms.StateSquid;

namespace FifteenPercentDrop.Views
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        void ChangeStateClicked(System.Object sender, System.EventArgs e)
        {
            var currentState = StateLayout.GetCurrentState(WeightStack);
            var newState = currentState == State.Success ? State.None : State.Success;
            StateLayout.SetCurrentState(WeightStack, newState);
            StateLayout.SetCurrentState(LoadStack, newState);
            StateLayout.SetCurrentState(TyreStack, newState);
        }

        ILogger Logger = new Logger();

        bool firstRender = true;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Logger.Log("Calcualtor Page Opened");
            if(firstRender)
            {
                await DisplayAlert("Caution", "CAUTION: Do not inflate tyre outside manufacturer's recommended range. Over/Underinflated tyres can lead to  dangerous punctures. There is debate about whether 15% drop is ideal.", "Okay");
            }
            firstRender = false;
        }
    }
}
