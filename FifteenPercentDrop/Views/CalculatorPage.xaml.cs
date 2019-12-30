using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FifteenPercentDrop.Views
{
    public partial class CalculatorPage : ContentPage
    {
        public void FocusWeightKeyboard(object sender, EventArgs e)
        {
            //VM.TotalWeight = null;
            WeightEntry.Focus();
        }

        public CalculatorPage()
        {
            InitializeComponent();
        }
    }
}
