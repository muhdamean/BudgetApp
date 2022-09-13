using System;
namespace BudgetApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public float StartingBalance { get; set; }
        public float Currentbalance { get; set; }
    }
}

