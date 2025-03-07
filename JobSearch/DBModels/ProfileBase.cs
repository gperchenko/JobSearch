namespace JobSearch.DBModels
{
    public class ProfileBase : EntityBase
    {
        public int ProfileId { get; set; }
        public Profile? Profile { get; set; }
    }
}
