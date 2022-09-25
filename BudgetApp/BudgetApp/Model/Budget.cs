using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Xamarin.Forms;

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
        [NotMapped]
        public Color Color => GetColor();

        private Color GetColor()
        {
            string[] color = { "#FFC44B", "#887DFB", "#21C8ED", "#3F32C7" };
            var index = new Random().Next(0, color.Count());

            return Color.FromHex(color[index]);
        }
    }

    public enum Duration
    {
        OneTime,
        Monthly,
        Yearly
    }
}

