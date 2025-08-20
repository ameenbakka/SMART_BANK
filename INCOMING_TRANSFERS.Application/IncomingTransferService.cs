using ACCOUNT.Application;
using INCOMING_TRANSFERS.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCOMING_TRANSFERS.Application
{
    public class IncomingTransferService : IIncomingTransferService
    {
        private readonly IIncomingTransferRepository _incomingTransferRepository;
        public IncomingTransferService(IIncomingTransferRepository incomingTransferRepository)
        {
            _incomingTransferRepository = incomingTransferRepository;
        }
        public async Task<ApiResponse<dynamic>> GetIncomingTransferById(int IncomingTransferId, int ReceiverUserId)
        {
            try
            {
                var result = await _incomingTransferRepository.GetIncomingTransferById(IncomingTransferId, ReceiverUserId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Retrived successfully",result);

                return new ApiResponse<dynamic>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<dynamic>(500, $"SQL Exception : {ex.Message}");
            }
            catch(Exception ex)
            {
                return new ApiResponse<dynamic>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> AddIncomingTransfer(IncomingTransfer transfer)
        {
            try
            {
                var result = await _incomingTransferRepository.AddIncomingTransfer(transfer);
                if (result > 0)
                    return new ApiResponse<int>(201, "IncomingTransfer Created Successfully",result);

                return new ApiResponse<int>(400, "Please verify that the entered information is correct.");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> UpdateIncomingTransfer(IncomingTransfer transfer)
        {
            try
            {
                var result = await _incomingTransferRepository.UpdateIncomingTransfer(transfer);
                if (result > 0)
                    return new ApiResponse<int>(200, "Updated Successfully",result);

                return new ApiResponse<int>(204, "No Content");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> DeleteIncomingTransfer(int IncomingTransferId)
        {
            try
            {
                var result = await _incomingTransferRepository.DeleteIncomingTransfer(IncomingTransferId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Deleted Successfully", result);

                return new ApiResponse<int>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
    }
}
