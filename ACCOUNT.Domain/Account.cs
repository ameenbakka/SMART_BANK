using System.Numerics;

namespace ACCOUNT.Domain
{
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public long AccountNumber { get; set; }
        public AccountTypes AccountType { get; set; }
        public AccountStatuses AccountStatus { get; set; }
        public decimal Balance { get; set; }
        public string BranchCode { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MinimumBalance { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
        public int BranchId { get; set; }

    }

    public enum AccountTypes
    {
        Savings,
        Current,
        FixedDeposit,
        RecurringDeposit,
        Salary,
        Loan,
        NRI,
        Joint,
        Demat,
        Overdraft,
        Custom
    }
    public enum AccountStatuses
    {
        Blocked,
        UnderReview,
        Frozen,
        Pending,
        Dormant,
        Suspended,
        Closed,
        Open
    }
}
