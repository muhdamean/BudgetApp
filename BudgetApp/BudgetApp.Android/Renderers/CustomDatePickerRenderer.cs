using System;
using Android.Content;
using BudgetApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePicker), typeof(CustomDatePickerRenderer))]
namespace BudgetApp.Droid.Renderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context) : base (context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Text = Element.Date.ToString("dd MMM yyyy").ToUpper();

                Element.DateSelected += (sender, args) =>
                {
                    Control.Text = Element.Date.ToString("dd MMM yyyy").ToUpper();
                };
            }

            if(e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}

