namespace BENEFICIARIES.Domain
{
    public class Beneficiary
    {
        public int BeneficiaryId { get; set; }
        public int UserId { get; set; }

        public string NickName { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public long AccountNumber { get; set; }
        public string IFSC_Code { get; set; }

        public TransactionType TransactionType { get; set; }
        public BeneficiaryStatus Status { get; set; }
        public VerificationStatus VerificationStatus { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }

    public enum TransactionType
    {
        NEFT,
        RTGS,
        IMPS
    }

    public enum BeneficiaryStatus
    {
        Pending,
        Active,
        Rejected,
        Inactive
    }

    public enum VerificationStatus
    {
        Unverified,
        Verified,
        Failed
    }


}
