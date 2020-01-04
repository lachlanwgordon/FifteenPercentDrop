using System;
using Xamarin.Forms;

namespace FifteenPercentDrop.Controls
{
    public partial class WeightEntry : ContentView
    {        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(WeightEntry), default(string), propertyChanged: OnTitleChanged);
        public string Title
        {
            get
            {
                return GetValue(TitleProperty) as string;
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }

        static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (WeightEntry)bindable;

                var value = newValue as string;

                control.ApplyTitle(value);
            }
            catch (Exception ex)
            {
                // TODO: Handle exception.
            }
        }

        void ApplyTitle(string value)
        {
            TitleLabel.Text = value;
        }


        public WeightEntry()
        {
            InitializeComponent();
        }

        public void FocusWeightKeyboard(object sender, EventArgs e)
        {
            WeightEditor.Focus();
        }

        public void IncrementWeight(object sender, EventArgs e)
        {
            Weight++;
        }

        public void DecrementWeight(object sender, EventArgs e)
        {
            Weight--;
        }



        public static readonly BindableProperty WeightProperty = BindableProperty.Create(nameof(Weight), typeof(double?), typeof(WeightEntry), default(double?), propertyChanged: OnWeightChanged, defaultBindingMode: BindingMode.TwoWay);
        public double? Weight
        {
            get
            {
                return (double?)GetValue(WeightProperty);
            }

            set
            {
                SetValue(WeightProperty, value);
            }
        }

        static void OnWeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (WeightEntry)bindable;

                var value = (double?)newValue;

                control.ApplyWeight(value);
            }
            catch (Exception ex)
            {
                // TODO: Handle exception.
            }
        }

        void ApplyWeight(double? value)
        {
            WeightEditor.Text = value.ToString();
        }

        void WeightEditor_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if(!e.NewTextValue.EndsWith(".") && double.TryParse(e.NewTextValue, out double weight))
            {
                Weight = weight;

            }
        }
    }
}