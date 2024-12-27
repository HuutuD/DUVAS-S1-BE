using DataAccess;
using DTO;
using DUVAS;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task DeleteTransactionAsync(Transaction b) => await TransactionDAO.DeleteTransactionAsync(b);
        public async Task<Transaction> GetTransactionByIdAsync(int id) => await TransactionDAO.FindTransactionByIdAsync(id);
        public async Task<List<TransactionDTO>> GetTransactionsAsync() => await TransactionDAO.GetTransactionsAsync();
        public async Task SaveTransactionAsync(Transaction b) => await TransactionDAO.SaveTransactionAsync(b);
        public async Task UpdateTransactionAsync(Transaction b) => await TransactionDAO.UpdateTransactionAsync(b);
    }
}
