namespace INCOMING_TRANSFERS.Domain
{
    public class IncomingTransfer
    {
        public int IncomingTransferId { get; set; }

        public string SenderName { get; set; }
        public string SenderBankName { get; set; }
        public long SenderAccountNumber { get; set; }
        public string SenderIFSCCode { get; set; }

        public int ReceiverUserId { get; set; }
        public long ReceiverAccountNumber { get; set; }

        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string UTRNumber { get; set; }
        public string Status { get; set; }

        public string Purpose { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
        
    }

}
