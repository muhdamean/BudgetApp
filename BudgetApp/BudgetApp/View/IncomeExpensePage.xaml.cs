using System;
using System.Collections.Generic;
using BudgetApp.Model;
using BudgetApp.ViewModel;
using Xamarin.Forms;

namespace BudgetApp.View
{
    public partial class IncomeExpensePage : ContentPage
    {
        public IncomeExpensePage(TransactionType transactionType)
        {
            InitializeComponent();
            Init(transactionType);
        }

        private IncomeExpenseVm vm;

        private void Init(TransactionType transactionType)
        {
            vm = new IncomeExpenseVm(transactionType);

            Titletxt.Text = vm.TransType == TransactionType.Expense ? "EXPENSE" : "INCOME ";
            Totaltxt.Text= vm.TransType == TransactionType.Expense ? "Total Expenses" : "Total Income";
            this.BindingContext = vm;
            
        }

        void AddTapped(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new NewIncomeExpensePage(transactionType), true);
        }
    }
}

