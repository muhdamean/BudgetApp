using System;
using BudgetApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePicker), typeof(CustomDatePickerRenderer))]
namespace BudgetApp.iOS.Renderers
{
    public class CustomDatePickerRenderer :DatePickerRenderer
    {
        public CustomDatePickerRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Text = Element.Date.ToString("dd MMM yyyy").ToUpper();

                Element.DateSelected += (sender, args) =>
                {
                    Control.Text = Element.Date.ToString("dd MMM yyyy").ToUpper();
                };
            }

            if (e.OldElement == null)
            {
                try
                {
                    Control.Background = null;
                    Control.BorderStyle = UIKit.UITextBorderStyle.None;
                    Control.Layer.BorderWidth = 0;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}

