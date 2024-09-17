using JobSearch.DBModels;

namespace JobSearch.Services
{
    public interface IJobSearchService
    {
        Task<Profile> SwitchProfileAsync(string profileName);
        Task<List<Resume>> GetResumesAsync(int profileId);
        Task AddResume(Resume resume);
    }
}
