using System;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace BudgetApp.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public TransactionType TransactionType { get; set; }

        [NotMapped]
        public Color Color => TransactionType == TransactionType.Income ? Color.FromHex("#21C8ED") : Color.FromHex("#FFC44B");
    }

    public enum TransactionType
    {
        Income = 1,
        Expense
    }
}



