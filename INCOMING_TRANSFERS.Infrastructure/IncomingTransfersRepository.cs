using Dapper;
using INCOMING_TRANSFERS.Application;
using INCOMING_TRANSFERS.Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace INCOMING_TRANSFERS.Infrastructure
{
    public class IncomingTransfersRepository : IIncomingTransferRepository
    {
        private readonly IDbConnection _db;
        public IncomingTransfersRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("defaultconnection"));
        }
        public async Task<dynamic> GetIncomingTransferById(int IncomingTransferId, int ReceiverUserId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETBYID");
            parameters.Add("@IncomingTransferId", IncomingTransferId);
            parameters.Add("@ReceiverUserId", ReceiverUserId);

            return await _db.QueryFirstOrDefaultAsync<IncomingTransfer>
                ("[dbo].[SP_IncomingTransfers]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> AddIncomingTransfer(IncomingTransfer transfer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "INSERT");
            parameters.Add("@SenderName", transfer.SenderName);
            parameters.Add("@SenderBankName", transfer.SenderBankName);
            parameters.Add("@SenderAccountNumber", transfer.SenderAccountNumber);
            parameters.Add("@SenderIFSCCode", transfer.SenderIFSCCode);
            parameters.Add("@ReceiverUserId", transfer.ReceiverUserId);
            parameters.Add("@ReceiverAccountNumber", transfer.ReceiverAccountNumber);
            parameters.Add("@Amount", transfer.Amount);
            parameters.Add("@TransactionType", transfer.TransactionType);
            parameters.Add("@UTRNumber", transfer.UTRNumber);
            parameters.Add("@Status", transfer.Status);
            parameters.Add("@Purpose", transfer.Purpose);
            parameters.Add("@CreatedBy", transfer.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_IncomingTransfers]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateIncomingTransfer(IncomingTransfer transfer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "UPDATE");
            parameters.Add("@IncomingTransferId", transfer.IncomingTransferId);
            parameters.Add("@SenderName", transfer.SenderName);
            parameters.Add("@SenderBankName", transfer.SenderBankName);
            parameters.Add("@SenderAccountNumber", transfer.SenderAccountNumber);
            parameters.Add("@SenderIFSCCode", transfer.SenderIFSCCode);
            parameters.Add("@ReceiverUserId", transfer.ReceiverUserId);
            parameters.Add("@ReceiverAccountNumber", transfer.ReceiverAccountNumber);
            parameters.Add("@Amount", transfer.Amount);
            parameters.Add("@TransactionType", transfer.TransactionType);
            parameters.Add("@UTRNumber", transfer.UTRNumber);
            parameters.Add("@Status", transfer.Status);
            parameters.Add("@Purpose", transfer.Purpose);
            parameters.Add("@UpdatedBy", transfer.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_IncomingTransfers]", parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<int> DeleteIncomingTransfer(int IncomingTransferId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "DELETE");
            parameters.Add("@IncomingTransfer", IncomingTransferId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_IncomingTransfers]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
