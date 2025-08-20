namespace LEDGER_ENTRIES.Domain
{
    public class LedgerEntry
    {
        public int LedgerEntryId { get; set; }
        public int AccountId { get; set; }
        public int TransactionId { get; set; }
        public string EntryType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string? Description { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Reconciled { get; set; }
        public DateTime? ReconciliationDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
