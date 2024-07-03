namespace JobSearch.Shared
{
    public class PageState
    {
        public DBModels.Profile Profile;
        public event Action? OnChange;
        
        public void NotifyStateChanged() => OnChange?.Invoke();

        public void UpdateProfile(string? profileName)
        {
            if (Profile == null)
            {
                Profile = new DBModels.Profile()
                {
                    Id = 1,
                    Name = profileName
                };
            }
            else
            {
                var newId = Profile.Id + 1;
                Profile = new DBModels.Profile()
                {
                    Id = newId,
                    Name = profileName
                };
            }
        }
    }
}
