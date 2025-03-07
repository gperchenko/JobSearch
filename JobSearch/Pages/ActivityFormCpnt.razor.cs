using JobSearch.DBModels;
using JobSearch.Shared;
using JobSearch.UIModels;

namespace JobSearch.Pages
{
    public partial class ActivityFormCpnt
    {
        private ActivityUI newActivity = new ActivityUI();
        
        private List<Contact>  RecruiterContactList = new List<Contact>();
        private List<Contact> CompanyContactList = new List<Contact>();
        private List<Resume> ResumeList = new List<Resume>();

        protected override async Task OnInitializedAsync()
        {
            RecruiterContactList = await JobSearchService.GetContactsAsync(PageState.Profile.Id, false);
            CompanyContactList = await JobSearchService.GetContactsAsync(PageState.Profile.Id, true);
            ResumeList = await JobSearchService.GetResumesAsync(PageState.Profile.Id);
        }

        private async Task AddActivityAsync()
        {
            var activity = new Activity()
            {
                Date = DateTime.Parse(newActivity.Date),
                Description = newActivity.Description,
                RecruiterContactId = newActivity.RecruiterContactId,
                CompanyContactId = newActivity.CompanyContactId,
                ResumeId = newActivity.ResumeId,
                Note = newActivity.Note,
                ProfileId = PageState.Profile.Id
            };

            await JobSearchService.AddActivityAsync(activity);

            newActivity = new ActivityUI();
            PageState.NotifyStateChanged();
        }
    }
}
