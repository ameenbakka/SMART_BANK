using ACCOUNT.Application;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TRANSACTION.Domain;

namespace TRANSACTION.Application
{
    public class TransactionServices : ITransactionServices
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionServices(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        
        public async Task<ApiResponse<int>> AddTransaction(Transactions transactions)
        {
            try
            {
                var result = await _transactionRepository.AddTransactionAsync(transactions);
                if (result > 0)
                    return new ApiResponse<int>(201, "Transaction Created Successfully", result);

                return new ApiResponse<int>(400, "Bad Request");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>
                    (500, $"SQL Error : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                    (500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> UpdateTransaction(Transactions transactions)
        {
            try
            {
                var result = await _transactionRepository.UpdateTransactionAsync(transactions);
                if (result > 0)
                    return new ApiResponse<int>(200, "Updated Successfully", result);

                return new ApiResponse<int>(204, "No Content");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>
                    (500, $"SQL Error : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                    (500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> DeleteTransaction(int TransactionId)
        {
            try
            {
                var result = await _transactionRepository.DeleteTransactionAsync(TransactionId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Deleted Successfully", result);

                return new ApiResponse<int>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>
                    (500, $"SQL Error : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                    (500, $"Unexpected Error : {ex.Message}");
            }
        }
    }
}
