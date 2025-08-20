namespace BRANCHES.Domain
{
    public class Branch
    {
        public long BranchId { get; set; }          
        public string BranchCode { get; set; }       
        public string BranchName { get; set; }       
        public string Ifsc_Code { get; set; }        
        public string Address { get; set; }          
        public string City { get; set; }            
        public string State { get; set; }            
        public string Country { get; set; }          
        public decimal? Latitude { get; set; }     
        public decimal? Longitude { get; set; }      
        public DateTime CreatedAt { get; set; }     
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }

}
