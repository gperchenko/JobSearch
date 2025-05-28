using JobSearch.UIModels;

namespace JobSearch.Shared
{
    public partial class ProfileCpnt
    {
        private Boolean loadedProfile = false;
        private ProfileUI newProfile = new ProfileUI();
        private string buttonDisabled = "bg-blue-300/20";
        private string buttonEnabled  = "cursor-pointer bg-blue-300";
        private string buttonCurrent = "";

        protected override async Task OnInitializedAsync()
        {
            buttonCurrent = buttonEnabled;
            loadedProfile = false;
        }
        private async Task SwitchProfile()
        {
            buttonCurrent = buttonDisabled;
            loadedProfile = true;

            PageState.Profile = await JobSearchService.SwitchProfileAsync(newProfile.Name);
            PageState.NotifyStateChanged();


            newProfile = new ProfileUI();
            buttonCurrent = buttonEnabled;
            loadedProfile = false;
        }
    }
}
