namespace JobSearch.DBModels
{
    public class Profile : EntityBase
    {        
        public string? Name { get; set; }
        public ICollection<Resume>? Resumes { get; set; }
    }
}
