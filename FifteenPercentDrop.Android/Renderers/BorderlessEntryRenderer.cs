using System;
using FifteenPercentDrop.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(BorderlessEntryRenderer))]
namespace FifteenPercentDrop.Droid.Renderers
{
    public class BorderlessEntryRenderer : EditorRenderer
    {
        public BorderlessEntryRenderer()
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.InputType = Android.Text.InputTypes.TextFlagNoSuggestions;
                Control.SetBackgroundColor(Android.Graphics.Color.Argb(0, 0, 0, 0));
            }
        }


    }
}
