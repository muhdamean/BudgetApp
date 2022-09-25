using System;
using System.Collections.Generic;
using BudgetApp.Data;
using BudgetApp.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using BudgetApp.View.Popup;

namespace BudgetApp.ViewModel
{
    public class NewIncomeExpenseVm : BaseVm
    {
        public NewIncomeExpenseVm()
        {
            service = new DataService();
            Category = GetBudgets();
        }
        private DataService service;
        
        public TransactionType TransactionType { get; set; }

        private List<Budget> budget;
        public List<Budget> Category
        {
            get { return budget; }
            set { budget=value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private float amount;
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private DateTime transactionDate = DateTime.Now;
        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        } 

        private int categoryIndex= -1;
        public int CategoryIndex
        {
            get { return categoryIndex; }
            set { categoryIndex = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public ICommand BackCommand => new Command(() =>
        {
            App.Current.MainPage.Navigation.PopAsync();
        });

        public ICommand SaveCommand => new Command(SaveTransaction);

        private async void SaveTransaction()
        {
            var transaction = new Transaction
            {
                Title = Title,
                Amount = Amount,
                Date = TransactionDate,
                Description = Description,
                TransactionType=TransactionType
            };
            if (categoryIndex > -1)
                transaction.Category = Category[categoryIndex].Title;

            var result=await service.AddTransactionAsync(transaction);

            if (result)
                MessageDialog.Show("Add Transaction", "Your transaction has been saved successfully.", "OK", () =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        
                        await App.Current.MainPage.Navigation.PopAsync();
                        MessagingCenter.Send(this, "update");
                    });
                });
            else
                MessageDialog.Show("Add Transaction", "There was an error while saving your ransaction. Please try again.", "OK");
        }

        private List<Budget> GetBudgets()
        {
            return service.QueryBudgets(x => x.DateCreated.Month == DateTime.Now.Month |
            x.Duration == Duration.Monthly).ToList();
        }
    } 
}

