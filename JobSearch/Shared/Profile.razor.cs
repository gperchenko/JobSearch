using JobSearch.UIModels;

namespace JobSearch.Shared
{
    public partial class Profile
    {
        private ProfileUI newProfile = new ProfileUI();

        private void ChangeProfile()
        {
            PageState.UpdateProfile(newProfile.Name);
            PageState.NotifyStateChanged();
        }
    }
}
