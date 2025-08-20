namespace NOMINEE.Domain
{
    public class Nominee
    {
        public int NomineeId { get; set; }
        public int USERID { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relation { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public decimal SharePercentage { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
