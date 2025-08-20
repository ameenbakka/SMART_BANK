namespace REMITTANCE.Domain
{
    public class Remittance
    {
        public int RemittanceId { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }
        public long AccountNumber { get; set; }
        public string IFSC_Code { get; set; }
        public string SwiftCode { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal FeeAmount { get; set; }
        public string Purpose { get; set; }
        public RemittanceStatus Status { get; set; }
        public string UTRNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
    }
    public enum TransactionType
    {
        NEFT,
        RTGS,
        IMPS,
        SWIFT
    }

    public enum RemittanceStatus
    {
        Pending,
        Completed,
        Failed,
        Cancelled
    }
}
