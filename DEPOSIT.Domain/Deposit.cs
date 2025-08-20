namespace DEPOSIT.Domain
{
    public class Deposit
    {
        public int DepositId { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }

        public DepositType DepositType { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }

        public int DepositTenure { get; set; }
        public InterestFrequency InterestFrequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public DepositStatus Status { get; set; }
        public bool AutoRenew { get; set; }
        public bool PrematureWithdraw { get; set; }

        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public enum DepositType
    {
        FixedDeposit,
        RecurringDeposit
    }

    public enum InterestFrequency
    {
        Monthly,
        Quarterly,
        Yearly
    }

    public enum DepositStatus
    {
        Pending,
        Active,
        Matured,
        Withdrawn,
        Cancelled
    }
}
