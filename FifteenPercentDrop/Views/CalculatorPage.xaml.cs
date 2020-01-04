using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
