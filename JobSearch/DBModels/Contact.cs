namespace JobSearch.DBModels
{
    public class Contact : ProfileBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Email { get; set; } 
        public string? Phone { get; set; } 
        public string? CompanyName { get; set; } 
        public bool IsHiring { get; set; }
        public ICollection<Activity>? AcivitiesByRecruiter { get; set; }
        public ICollection<Activity>? ActivitiesByCompany { get; set; }
    }
}
