namespace USER_AUDIT_LOGS.Domain
{
    public class UserAuditLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; } = string.Empty;

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }

}
