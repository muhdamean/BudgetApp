using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Model
{
    public class Budget
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Amount { get; set; }
        public Duration Duration { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [NotMapped]
        public float AmountSpent { get; set; }
        [NotMapped]
        public float Percentage=>  (AmountSpent / Amount) * 100;
    }

    public enum Duration
    {
        OneTime,
        Monthly,
        Yearly
    }
}

