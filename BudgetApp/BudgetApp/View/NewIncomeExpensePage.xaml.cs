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
            this.type = type;

            if (type == TransactionType.Income)
                IncomeSelected(this, new EventArgs());
            else
                ExpenseSelected(this, new EventArgs());
        }
        private TransactionType type;

        void IncomeSelected(System.Object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(ExpenseTab, "Normal");
            VisualStateManager.GoToState(IncomeTab, "Selected");

            ExpenseTabTxt.TextColor = Color.FromHex("#2C2A57");
            IncomeTabTxt.TextColor = Color.White;

            CategoryView.IsVisible = false;
        }

        void ExpenseSelected(System.Object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(IncomeTab, "Normal");
            VisualStateManager.GoToState(ExpenseTab, "Selected");

            IncomeTabTxt.TextColor = Color.FromHex("#2C2A57");
            ExpenseTabTxt.TextColor = Color.White;

            CategoryView.IsVisible = true;
        }
    }
}

