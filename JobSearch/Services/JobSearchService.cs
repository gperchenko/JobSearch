using JobSearch.Context;

namespace JobSearch.Services
{
    public class JobSearchService : IJobSearchService
    {
        private readonly JobSearchContext _context;

        public JobSearchService(JobSearchContext context)
        {
            _context = context;
        }
    }
}
