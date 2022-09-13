using System;
using BudgetApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Roboto-Regular.ttf", Alias ="NormalFont")]
[assembly: ExportFont("Roboto-Medium.ttf", Alias = "MediumFont")]
[assembly: ExportFont("Roboto-Bold.ttf", Alias = "BoldFont")]
[assembly: ExportFont("Roboto-Light.ttf", Alias = "LightFont")]
namespace BudgetApp
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            //Device.SetFlags(new[] { "Shapes_Experimental" });
            MainPage = new NavigationPage(new DashboardPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

