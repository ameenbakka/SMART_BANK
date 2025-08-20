namespace DIGITAL_SESSIONS.Domain
{
    public class DigitalSession
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string IpAddress { get; set; }
        public bool? IsTrusted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }

}
