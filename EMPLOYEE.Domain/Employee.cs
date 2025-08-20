namespace EMPLOYEE.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int BranchId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public Roles Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
    }
    public enum Roles
    {
        Manager, 
        Teller, 
        Clerk, 
        LoanOfficer,
        Admin, 
        CustomerSupport, 
        Auditor,
        BranchHead,
        RelationshipManager,
        Cashier,
        ITOfficer,
        SecurityOfficer,
        Accountant
    }
}
