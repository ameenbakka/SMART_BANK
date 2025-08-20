using INCOMING_TRANSFERS.Domain;

namespace INCOMING_TRANSFERS.Application
{
    public interface IIncomingTransferRepository
    {
        Task<dynamic> GetIncomingTransferById(int IncomingTransferId, int ReceiverUserId);
        Task<int> AddIncomingTransfer(IncomingTransfer transfer);
        Task<int> UpdateIncomingTransfer(IncomingTransfer transfer);
        Task<int> DeleteIncomingTransfer(int IncomingTransferId);
    }
}
