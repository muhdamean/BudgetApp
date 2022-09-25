﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BudgetApp.Data;
using BudgetApp.Model;
using BudgetApp.View;
using Xamarin.Forms;

namespace BudgetApp.ViewModel
{
    public class IncomeExpenseVm : BaseVm
    {
        public IncomeExpenseVm(TransactionType transactionType)
        {
            Init(transactionType);
        }
        private DataService service;
        public TransactionType TransType { get; set; }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private List<Transaction> transaction;
        public List<Transaction> Transactions
        {
            get { return transaction; }
            set
            {
                transaction = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalAmount));
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

        public float TotalAmount => Transactions.Sum(x => x.Amount);

        public ICommand BackCommand => new Command(() =>
        {
            App.Current.MainPage.Navigation.PopAsync();
        });

        public ICommand NewCommand => new Command(() =>
        {
            App.Current.MainPage.Navigation.PushAsync(new NewIncomeExpensePage(TransType));
        });

        public ICommand RefreshCommand => new Command(() =>
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            GetTransaction();
            IsRefreshing = false;
        });

        private void Init(TransactionType transactionType)
        {
            service = new DataService();
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDate = startDate.AddMonths(1).AddDays(-1);
            TransType = transactionType;
            GetTransaction();
        }

        private void GetTransaction()
        {
            Transactions = service.QueryTransactions(x => x.Date >= startDate &&
                x.Date <= endDate && x.TransactionType == TransType).ToList();
        }
    }
}

