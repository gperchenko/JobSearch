namespace JobSearch.DBModels
{
    public class Activity : ProfileBase
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; } 
        public int? RecruiterContactId { get; set; }
        public Contact? RecruiterContact { get; set; } 
        public int? CompanyContactId { get; set; }
        public Contact? CompanyContact { get; set; }
        public int? ResumeId { get; set; }
        public Resume? Resume { get; set; }
        public string? Note { get; set; }

    }
}
