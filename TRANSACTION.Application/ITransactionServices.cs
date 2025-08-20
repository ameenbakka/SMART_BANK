using ACCOUNT.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRANSACTION.Domain;

namespace TRANSACTION.Application
{
    public interface ITransactionServices
    {
        Task<ApiResponse<int>> AddTransaction(Transactions transactions);
        Task<ApiResponse<int>> UpdateTransaction(Transactions transactions);
        Task<ApiResponse<int>> DeleteTransaction(int TransactionId);
    }
}
