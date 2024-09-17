using JobSearch.UIModels;

namespace JobSearch.Shared
{
    public partial class ProfileCpnt
    {
        private ProfileUI newProfile = new ProfileUI();

        private async Task SwitchProfile()
        {
            PageState.Profile = await JobSearchService.SwitchProfileAsync(newProfile.Name);
            PageState.NotifyStateChanged();
        }
    }
}
