using System;
using System.Collections.Generic;
using BudgetApp.Model;
using Xamarin.Forms;

namespace BudgetApp.View
{
    public partial class IncomeExpensePage : ContentPage
    {
        public IncomeExpensePage(TransactionType transactionType)
        {
            InitializeComponent();
            this.transactionType = transactionType;
            Init(this.transactionType);
        }

        private TransactionType transactionType;

        private void Init(TransactionType type)
        {
            Titletxt.Text = type == TransactionType.Expense ? "EXPENSE" : "INCOME ";
        }

        void AddTapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewIncomeExpensePage(transactionType), true);
        }
    }
}

