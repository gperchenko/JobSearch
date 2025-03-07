using JobSearch.DBModels;

namespace JobSearch.Services
{
    public interface IJobSearchService
    {
        Task<Profile> SwitchProfileAsync(string profileName);
        Task<List<Resume>> GetResumesAsync(int profileId);
        Task AddResumeAsync(Resume resume);
        Task<List<Contact>> GetContactsAsync(int profileId);
        Task<List<Contact>> GetContactsAsync(int profileId, bool isHiring);
        Task AddContactAsync(Contact contact);
        Task<List<Activity>> GetActivitiesAsync(int profileId);
        Task AddActivityAsync(Activity activity);
    }
}
