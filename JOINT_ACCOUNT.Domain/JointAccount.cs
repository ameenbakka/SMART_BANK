namespace JOINT_ACCOUNT.Domain
{
    public class JointAccount
    {
        public int JointAccountId { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }

        public string Relationship { get; set; }
        public JointTypes JointType { get; set; } 

        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public enum JointTypes
    {
        EitherOrSurvivor, 
        AllOrSurvivor
    }

}
