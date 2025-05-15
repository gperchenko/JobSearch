using JobSearch.UIModels;

namespace JobSearch.Shared
{
    public partial class ProfileCpnt
    {
        private Boolean LoadingProfile = false;
        private ProfileUI newProfile = new ProfileUI();
        private string buttonDisabled = "bg-blue-300/20";
        private string buttonEnabled  = "cursor-pointer bg-blue-300";
        private string buttonCurrent = "";

        protected override async Task OnInitializedAsync()
        {
            buttonCurrent = buttonEnabled;
            LoadingProfile = false;
        }
        private async Task SwitchProfile()
        {
            buttonCurrent = buttonDisabled;
            LoadingProfile = true;
           
            PageState.Profile = await JobSearchService.SwitchProfileAsync(newProfile.Name);
     
            newProfile = new ProfileUI();
            buttonCurrent = buttonEnabled;
            LoadingProfile = false;
        }
    }
}
