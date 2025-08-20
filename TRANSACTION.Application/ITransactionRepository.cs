using TRANSACTION.Domain;

namespace TRANSACTION.Application
{
    public interface ITransactionRepository
    {
        Task<int> AddTransactionAsync(Transactions transaction);
        Task<int> UpdateTransactionAsync(Transactions transaction);
        Task<int> DeleteTransactionAsync(int TransactionId);
    }
}
