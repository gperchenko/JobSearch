using JobSearch.Context;
using JobSearch.DBModels;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Services
{
    public class JobSearchService : IJobSearchService
    {
        private readonly JobSearchContext _context;

        public JobSearchService(JobSearchContext context)
        {
            _context = context;
        }

        public async Task AddResume(Resume resume)
        {
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
        }

        public Task<List<Resume>> GetResumesAsync(int profileId)
        {
            return _context.Resumes
                .Where(x => x.ProfileId == profileId)
                .ToListAsync();
        }

        public async Task<Profile> SwitchProfileAsync(string profileName)
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Name == profileName);
            if (profile == null)
            {
                profile = new Profile { Name = profileName };
                _context.Profiles.Add(profile);
                await _context.SaveChangesAsync();
            }

            return profile;
        }
    }
}
