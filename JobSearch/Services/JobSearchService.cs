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

        public async Task AddActivityAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task AddResumeAsync(Resume resume)
        {
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
        }

        public Task<List<Activity>> GetActivitiesAsync(int profileId)
        {
            return _context.Activities
                .Where(x => x.ProfileId == profileId)
                .Include(x => x.RecruiterContact)
                .Include(x => x.CompanyContact)
                .Include(x => x.Resume)
                .ToListAsync();
        }

        public Task<List<Contact>> GetContactsAsync(int profileId)
        {
            return _context.Contacts
                .Where(x => x.ProfileId == profileId)
                .ToListAsync();
        }

        public Task<List<Contact>> GetContactsAsync(int profileId, bool isHiring)
        {
            return _context.Contacts
                .Where(x => x.ProfileId == profileId && x.IsHiring == isHiring)
                .ToListAsync();
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
