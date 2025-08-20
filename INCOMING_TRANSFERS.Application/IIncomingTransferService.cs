using ACCOUNT.Application;
using INCOMING_TRANSFERS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCOMING_TRANSFERS.Application
{
    public interface IIncomingTransferService
    {
        Task<ApiResponse<dynamic>> GetIncomingTransferById(int IncomingTransferId, int ReceiverUserId);
        Task<ApiResponse<int>> AddIncomingTransfer(IncomingTransfer transfer);
        Task<ApiResponse<int>> UpdateIncomingTransfer(IncomingTransfer transfer);
        Task<ApiResponse<int>> DeleteIncomingTransfer(int IncomingTransferId);
    }
}
