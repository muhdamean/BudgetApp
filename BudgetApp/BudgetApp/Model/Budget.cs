using System;
namespace BudgetApp.Model
{
    public class Budget
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Amount { get; set; }
        public Duration Duration { get; set; }
        public string Description { get; set; }
    }

    public enum Duration
    {
        OneTime,
        Monthly,
        Yearly
    }
}

