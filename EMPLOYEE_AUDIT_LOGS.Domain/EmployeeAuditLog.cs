namespace EMPLOYEE_AUDIT_LOGS.Domain
{
    public class EmployeeAuditLog
    {
        public int LogId { get; set; }
        public int EmployeeId { get; set; }
        public string Action { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }

}
