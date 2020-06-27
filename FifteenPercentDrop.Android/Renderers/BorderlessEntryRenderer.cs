using System;
using Android.Content;
using Android.Graphics.Drawables;
using FifteenPercentDrop.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(Entry), typeof(BorderlessEntryRenderer))]
namespace FifteenPercentDrop.Droid.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context) 
        {
            System.Diagnostics.Debug.WriteLine($"use new renderer");
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.Transparent);
                Control.SetBackground(gd);
            }
        }
    }
}
