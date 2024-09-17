namespace JobSearch.DBModels
{
    public class Profile : EntityBasse
    {        
        public string? Name { get; set; }
        public List<Resume> Resumes { get; set; }
    }
}
