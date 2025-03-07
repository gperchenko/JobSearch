using JobSearch.DBModels;
using JobSearch.Shared;

namespace JobSearch.Pages
{
    public partial class ActivityListCpnt : IDisposable
    {
        private List<Activity> activities = new List<Activity>();
       
        protected override async Task OnInitializedAsync()
        {
            PageState.OnChange += ReloadComponentAsync;

            await ReloadDataAsync();
        }

        private async void ReloadComponentAsync()
        {
            // InvokeAsync is inherited, it syncs the call back to the render thread
            await InvokeAsync(async () => {
                await ReloadDataAsync();
                StateHasChanged();
            });
        }

        private async Task ReloadDataAsync()
        {
            if (PageState?.Profile != null)
            {
                activities = await JobSearchService.GetActivitiesAsync(PageState.Profile.Id);
            }
        }

        public void Dispose()
        {
            PageState.OnChange -= ReloadComponentAsync;
        }
    }
}
