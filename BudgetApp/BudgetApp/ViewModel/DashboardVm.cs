using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using BudgetApp.Data;
using BudgetApp.Model;
using BudgetApp.View;
using BudgetApp.View.Popup;

namespace BudgetApp.ViewModel
{
    public class DashboardVm : BaseVm
    {
        public DashboardVm()
        {
            service = new DataService();
            MenuList = GetMenu();
            GetTransactions();
        }
        private DataService service;

        private ObservableCollection<Menu> menuList;

        public ObservableCollection<Menu> MenuList
        {
            get { return menuList; }
            set { menuList = value; }
        }

        private List<Transaction> transactions;
        public List<Transaction> Transactions
        {
            get { return transactions; }
            set
            {
                transactions = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentBalance));
                OnPropertyChanged(nameof(CurrentIncome));
                OnPropertyChanged(nameof(CurrentExpenses));
                OnPropertyChanged(nameof(RecenetTransactions));
            }
        }

        public float CurrentBalance { get; set; }
        public float CurrentIncome { get; set; }
        public float CurrentExpenses { get; set; }
        public List<Transaction> RecenetTransactions { get; set; }

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

        public ICommand RefreshCommand => new Xamarin.Forms.Command(() =>
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            GetTransactions();
            IsRefreshing = false;
        });

        

       

        private async void GetTransactions()
        {
            var transactions = await service.GetTransactionsAsync();
            Transactions = transactions.ToList();

            var endDate = DateTime.Now;
            var startDate = endDate.AddDays(-7);

            RecenetTransactions = Transactions.Where(x => x.Date >= startDate && x.Date <= endDate).OrderByDescending(x=>x.Date).ToList();
            CurrentIncome = RecenetTransactions.Where(x => x.TransactionType == TransactionType.Income).Sum(x => x.Amount);
            CurrentExpenses = RecenetTransactions.Where(x => x.TransactionType == TransactionType.Expense).Sum(x => x.Amount);

            CurrentBalance = Transactions.Where(x => x.TransactionType == TransactionType.Income).Sum(x => x.Amount) -
                            Transactions.Where(x => x.TransactionType == TransactionType.Expense).Sum(x => x.Amount);
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

