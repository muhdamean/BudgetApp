using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BudgetApp.View
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        void MenuTapped(System.Object sender, System.EventArgs e)
        {
            OpenMenu();
        }

        private void OpenMenu()
        {
            MenuGrid.IsVisible = true;

            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, -260, 0, 16, 300, Easing.CubicInOut);
        }

        private void CloseMenu()
        {
            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, 0, -260, 16, 300, Easing.CubicInOut);

            MenuGrid.IsVisible = false;

        }

        void Overlaytapped(System.Object sender, System.EventArgs e)
        {
            CloseMenu();
        }
    }
}

