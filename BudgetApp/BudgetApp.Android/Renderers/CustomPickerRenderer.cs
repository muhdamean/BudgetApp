using System;
using Android.Content;
using BudgetApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace BudgetApp.Droid.Renderers
{
    public class CustomPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Background = null;
            }
        }
    }
}

