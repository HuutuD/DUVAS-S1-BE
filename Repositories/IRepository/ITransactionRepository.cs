using DTO;
using DUVAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ITransactionRepository
    {
        Task SaveTransactionAsync(Transaction b);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task DeleteTransactionAsync(Transaction b);
        Task UpdateTransactionAsync(Transaction b);
        Task<List<TransactionDTO>> GetTransactionsAsync();
    }
}
