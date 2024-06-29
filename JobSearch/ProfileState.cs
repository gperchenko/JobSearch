
using JobSearch.DBModels;

namespace JobSearch
{
    public class ProfileState
    {
        public Profile Profile { get; set; }

        public void Update(string profileName) 
        {
            if (Profile == null)
            {
                Profile = new Profile()
                {
                    Id = 1,
                    Name = profileName
                };
            }
            else
            {
                var newId = Profile.Id + 1;
                Profile = new Profile()
                {
                    Id = newId,
                    Name = profileName
                };
            }
        }
    }
}
