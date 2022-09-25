using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetApp.Data;
using BudgetApp.Model;
using BudgetApp.View;
using Xamarin.Forms;

namespace BudgetApp.ViewModel
{
    public class BudgetVm : BaseVm
    {
        public BudgetVm()
        {
            service = new DataService();
            GetBudgets();
        }
        private DataService service;

        public float TotalBudget => Budgets.Sum(x => x.Amount);
        public DateTime CurrentMonth => DateTime.Now;

        private List<Budget> budgets;

        public List<Budget> Budgets
        {
            get { return budgets; }
            set
            {
                budgets = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalBudget));
            }
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand BackCommand => new Command(() =>
        {
            App.Current.MainPage.Navigation.PopAsync();
        });

        public ICommand AddCommand => new Command(() =>
        {
            App.Current.MainPage.Navigation.PushAsync(new NewBudgetPage());
        });

        public ICommand RefreshCommand => new Command(() =>
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            GetBudgets();
            IsRefreshing = false;
        });

        private void GetBudgets()
        {
            var budgets = service.QueryBudgets(x => x.DateCreated.Month == DateTime.Now.Month |
             x.Duration == Duration.Monthly).ToList();

            if (budgets.Count() > 0)
            {
                var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                var transactions = service.QueryTransactions(x => x.Date >= startDate && x.Date <= endDate
                                        && x.TransactionType== TransactionType.Expense).ToList();

                foreach (var budget in budgets)
                {
                    budget.AmountSpent = transactions.Where(x => x.Category == budget.Title).Sum(x => x.Amount);
                }
            }
            Budgets = budgets;
            // Budgets = service.QueryBudgets(x => x.DateCreated.Month == DateTime.Now.Month |
            // x.Duration == Duration.Monthly).ToList();
        }
    }
}

