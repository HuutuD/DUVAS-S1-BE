using DTO;
using DUVAS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransactionDAO
    {
        private readonly ApplicationDbContext _context;

        public TransactionDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public static async Task<List<TransactionDTO>> GetTransactionsAsync()
        {

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var transactions = await context.Transactions
                        .AsNoTracking()
                        .Select(p => new TransactionDTO
                        {
                            TransactionId = p.TransactionId,
                            TransactionDateTime = p.TransactionDateTime,
                            Money = p.Money,
                            TransactionType = p.TransactionType,
                            RoomId = p.RoomId,
                            ServicePostId = p.ServicePostId,


                            //CategoryName = p.Category.CategoryName,
                            //CategoryId = p.CategoryId,                            

                        })
                        .ToListAsync();


                    return transactions;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static async Task<Transaction> FindTransactionByIdAsync(int transactionId)
        {
            Transaction transaction = null;
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    transaction = await context.Transactions.SingleOrDefaultAsync(x => x.TransactionId == transactionId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return transaction;
        }

        public static async Task SaveTransactionAsync(Transaction transaction)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    await context.Transactions.AddAsync(transaction);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task UpdateTransactionAsync(Transaction transaction)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(transaction).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task DeleteTransactionAsync(Transaction transaction)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var existingTransaction = await context.Transactions.SingleOrDefaultAsync(c => c.TransactionId == transaction.TransactionId);
                    if (existingTransaction != null)
                    {
                        context.Transactions.Remove(existingTransaction);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
