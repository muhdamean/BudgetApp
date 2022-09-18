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
        
        public ICommand AddCommand => new Command(() =>
        {
            App.Current.MainPage.Navigation.PushAsync(new NewBudgetPage());
        });

        private async void GetBudgets()
        {
            var budgets= await service.GetBudgetsAsync();
            Budgets= budgets.Where(x=>x.DateCreated.Month==DateTime.Now.Month |
            x.Duration==Duration.Monthly).ToList();
        }
    }
}

