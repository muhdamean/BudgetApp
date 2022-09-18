using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class DataService
    {
        private readonly AppDbContext context;
        public DataService()
        {
            context = new AppDbContext();
        }
        //Add Budget
        //Update Budget
        //Delete Budget
        //Get all Budget
        //Get single Budget by Id
        //Query Budget

        //Section for Transaction Data Services
        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                var result =await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return true;// result.State == EntityState.Added;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTransactionAsync(Transaction transaction)
        {
            try
            {
                var result = context.Transactions.Update(transaction);
                await context.SaveChangesAsync();

                return true;// result.State == EntityState.Modified;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTransactionAsync(Transaction transaction)
        {
            try
            {
                var result = context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();

                return true;// result.State == EntityState.Deleted;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            try
            {
                var result =await context.Transactions.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            try
            {
                var result = await context.Transactions.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Transaction> QueryTransactions(Func<Transaction, bool> predicate)
        {
            try
            {
                var result = context.Transactions.Where(predicate);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Section for Budget Data Services
        public async Task<bool> AddBudgetAsync(Budget budget)
        {
            try
            {
                var result = await context.Budgets.AddAsync(budget);
                await context.SaveChangesAsync();

                return true;// result.State == EntityState.Added;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBudgetAsync(Budget budget)
        {
            try
            {
                var result = context.Budgets.Update(budget);
                await context.SaveChangesAsync();

                return true;// result.State == EntityState.Modified;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBudgetAsync(Budget budget)
        {
            try
            {
                var result = context.Budgets.Remove(budget);
                await context.SaveChangesAsync();

                return true;// result.State == EntityState.Deleted;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            try
            {
                var result = await context.Budgets.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Budget> GetBudgetByIdAsync(int id)
        {
            try
            {
                var result = await context.Budgets.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Budget> QueryBudgets(Func<Budget, bool> predicate)
        {
            try
            {
                var result = context.Budgets.Where(predicate);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

