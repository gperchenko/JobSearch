namespace JobSearch.DBModels
{
    public class Resume : EntityBasse
    {
        public string? FileName { get; set; }
        public string? Description { get; set; }
        public int ProfileId { get; set; }
        public Profile? Profile { get; set; }
    }
}
