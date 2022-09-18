using System;
using System.IO;
using BudgetApp.Model;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace BudgetApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        static readonly string _databasePath = Path.Combine(FileSystem.AppDataDirectory, "BudgetDb.db");

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}

