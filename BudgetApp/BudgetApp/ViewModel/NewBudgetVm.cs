using System;
using System.Windows.Input;
using BudgetApp.Data;
using BudgetApp.Model;
using BudgetApp.View.Popup;
using Xamarin.Forms;

namespace BudgetApp.ViewModel
{
    public class NewBudgetVm : BaseVm
    {
        public NewBudgetVm()
        {
            service = new DataService();
        }
        private DataService service;

        private string budgetName;
        public string BudgetName
        { get { return budgetName; }
          set { budgetName = value; }
        }

        private float amount;
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private int duration;
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public ICommand SaveCommand => new Command(SaveBudget);

        public async void SaveBudget()
        {
            var budget = new Budget
            {
                Title = BudgetName,
                Amount = Amount,
                Duration = (Duration)Duration,
                Description = Description
            };

            var result=await service.AddBudgetAsync(budget);

            if (result)
                MessageDialog.Show("Add Budget", "Your budget has been saved successfully.", "OK", () =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await App.Current.MainPage.Navigation.PopAsync();
                    });
                });
            else
                MessageDialog.Show("Add Budget", "There was an error while saving your budget. Please try again.", "OK");
        }
    }
}

