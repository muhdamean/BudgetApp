using System;
using System.Collections.ObjectModel;
using BudgetApp.Model;

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
                new Menu{ Icon="income.png", Name="Income" },
                new Menu{ Icon="expenses.png", Name="Expense" },
                new Menu{ Icon="budget.png", Name="Budgets" },
                new Menu{ Icon="settings.png", Name="Settings" }
            };
        }
    }
}

