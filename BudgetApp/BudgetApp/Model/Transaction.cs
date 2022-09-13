using System;
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
        public string TransactionType { get; set; }
    }

    public enum TransactionType
    {
        Income = 1,
        Expense
    }
}



