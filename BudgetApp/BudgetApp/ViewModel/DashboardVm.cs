using System;
using System.Collections.ObjectModel;
using BudgetApp.Model;
using BudgetApp.View;

namespace BudgetApp.ViewModel
{
    public class DashboardVm : BaseVm
    {
        public DashboardVm()
        {
            MenuList = GetMenu();
        }

        private ObservableCollection<Menu> menuList;

        public ObservableCollection<Menu> MenuList
        {
            get { return menuList; }
            set { menuList = value; }
        }

        private ObservableCollection<Menu> GetMenu()
        {
            return new ObservableCollection<Menu>
            {
                new Menu{ Icon="income.png", Name="Income", TargetType=typeof(IncomeExpensePage) },
                new Menu{ Icon="expenses.png", Name="Expense", TargetType=typeof(IncomeExpensePage) },
                new Menu{ Icon="budget.png", Name="Budgets", TargetType=typeof(BudgetPage) },
                new Menu{ Icon="settings.png", Name="Settings" }
            };
        }
    }
}

