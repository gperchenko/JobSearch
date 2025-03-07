using JobSearch.DBModels;
using JobSearch.UIModels;

namespace JobSearch.Pages
{
    public partial class ResumeFormCpnt
    {
        private ResumeUI newResume = new ResumeUI();

        private async Task AddResumeAsync()
        {
            var resume = new Resume()
            {
                FileName = newResume.FileName,
                Description = newResume.Description,
                ProfileId = PageState.Profile.Id
            };

            await JobSearchService.AddResumeAsync(resume);
            PageState.NotifyStateChanged();
        }
    }
}
