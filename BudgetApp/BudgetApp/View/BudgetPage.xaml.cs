using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BudgetApp.View
{
    public partial class BudgetPage : ContentPage
    {
        public BudgetPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<NewBudgetPage>(this, "update", (obj)=>
            {
                vm.RefreshCommand.Execute(null);
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<NewBudgetPage>(this, "update");
        }
    }
}

