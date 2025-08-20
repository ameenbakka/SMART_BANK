using System.Numerics;

namespace TRANSACTION.Domain
{
    public class Transactions
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BeneficiaryId { get; set; }
        public int RemittanceId { get; set; }
        public int IncomingTransferId { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public long FromAccountNumber { get; set; }
        public long ToAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionMethod { get; set; }
        public string TransactionStatus { get; set; }
        public string Description { get; set; }
        public int AttemptCount { get; set; }
        public bool Reversed { get; set; }
        public bool FraudFlag { get; set; }
        public bool IsDelete { get; set; }
        public string DeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
