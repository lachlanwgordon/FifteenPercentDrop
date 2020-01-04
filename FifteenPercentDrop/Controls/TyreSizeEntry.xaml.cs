using System;
using Xamarin.Forms;
using FifteenPercentDrop.Controls;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPercentDrop.Controls
{
    public partial class TyreSizeEntry : ContentView
    {
        public static readonly BindableProperty TyreWidthsProperty = BindableProperty.Create(nameof(TyreWidths), typeof(List<double>), typeof(TyreSizeEntry), default(List<double>), propertyChanged: OnTyreWidthsChanged);
        public List<double> TyreWidths
        {
            get
            {
                return (List<double>)GetValue(TyreWidthsProperty);
            }

            set
            {
                SetValue(TyreWidthsProperty, value);
            }
        }

        static void OnTyreWidthsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (TyreSizeEntry)bindable;

                var value = (List<double>)newValue;

                control.ApplyTyreWidths(value);
            }
            catch (Exception ex)
            {
                // TODO: Handle exception.
            }
        }

        void ApplyTyreWidths(List<double> value)
        {
            SizePicker.ItemsSource = value;
            if (value.Count > 0)
            {
                SizePicker.SelectedItem = value.FirstOrDefault(); ;
            }

        }

        public static readonly BindableProperty TyreWidthProperty = BindableProperty.Create(nameof(TyreWidth), typeof(double), typeof(TyreSizeEntry), default(double), propertyChanged: OnTyreWidthChanged, defaultBindingMode: BindingMode.TwoWay);
        public double TyreWidth
        {
            get
            {
                return (double)GetValue(TyreWidthProperty);
            }

            set
            {
                SetValue(TyreWidthProperty, value);
            }
        }

        static void OnTyreWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (TyreSizeEntry)bindable;

                var value = (double)newValue;

                control.ApplyTyreWidth(value);
            }
            catch (Exception ex)
            {
                // TODO: Handle exception.
            }
        }

        void ApplyTyreWidth(double value)
        {
            SizePicker.SelectedItem = TyreWidths.FirstOrDefault(x => x == value);
        }

        public void DecrementWidth(object sender, EventArgs e)
        {
            double incremented = TyreWidths.ElementAtOrDefault(TyreWidths.IndexOf(TyreWidth) - 1);

            if (incremented != 0)
                TyreWidth = incremented;
        }

        public void IncrementWidth(object sender, EventArgs e)
        {
            double incremented = TyreWidths.ElementAtOrDefault(TyreWidths.IndexOf(TyreWidth) + 1);

            if (incremented != 0)
                TyreWidth = incremented;
        }





        public TyreSizeEntry()
        {
            InitializeComponent();
        }

        void SizePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var size = (double)SizePicker.SelectedItem;
            TyreWidth = size;
        }
    }
}