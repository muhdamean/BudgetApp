using System;
using System.Collections.Generic;
using BudgetApp.Model;
using Xamarin.Forms;

namespace BudgetApp.View
{
    public partial class NewIncomeExpensePage : ContentPage
    {
        public NewIncomeExpensePage()
        {
            InitializeComponent();
            IncomeSelected(this, new EventArgs());
        }
        public NewIncomeExpensePage(TransactionType type)
        {
            InitializeComponent();
            vm.TransactionType = type;

            if (vm.TransactionType == TransactionType.Income)
                IncomeSelected(this, new EventArgs());
            else
                ExpenseSelected(this, new EventArgs());
        }

        void IncomeSelected(System.Object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(ExpenseTab, "Normal");
            VisualStateManager.GoToState(IncomeTab, "Selected");

            ExpenseTabTxt.TextColor = Color.FromHex("#2C2A57");
            IncomeTabTxt.TextColor = Color.White;
            vm.TransactionType = TransactionType.Income;
            TitleTxt.Text = "NEW INCOME";
            CategoryView.IsVisible = false;
        }

        void ExpenseSelected(System.Object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(IncomeTab, "Normal");
            VisualStateManager.GoToState(ExpenseTab, "Selected");

            IncomeTabTxt.TextColor = Color.FromHex("#2C2A57");
            ExpenseTabTxt.TextColor = Color.White;
            vm.TransactionType = TransactionType.Expense;
            TitleTxt.Text = "NEW EXPENSE";
            CategoryView.IsVisible = true;
        }
    }
}

