using System;
using System.Collections.Generic;
using BudgetApp.Model;
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

        private void Overlaytapped(System.Object sender, System.EventArgs e)
        {
            CloseMenu();
        }

        private void MenuItemTapped(System.Object sender, System.EventArgs e)
        {
            var item = ((sender as StackLayout).BindingContext) as Model.Menu;

            if(item.TargetType== typeof(IncomeExpensePage))
            {
                var transactionType = item.Name == "Expense" ?
                    TransactionType.Expense : TransactionType.Income;
                var page = (Page)Activator.CreateInstance(item.TargetType, transactionType);

                Navigation.PushAsync(page);
            }
            else
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                Navigation.PushModalAsync(page);
            }
            CloseMenu();
        }

        void AddTapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewIncomeExpensePage(), true);
        }
    }
}

