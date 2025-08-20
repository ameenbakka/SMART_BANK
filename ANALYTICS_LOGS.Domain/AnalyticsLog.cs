namespace ANALYTICS_LOGS.Domain
{
    public class AnalyticsLog
    {
        public int LogId { get; set; }
        public string Module { get; set; }      // e.g., "Transactions", "Accounts"
        public string Metric { get; set; }      // e.g., "TotalDeposits", "LoginCount"
        public decimal Value { get; set; }      // 18,3 precision

        public DateTime LoggedAt { get; set; }  

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }

}
