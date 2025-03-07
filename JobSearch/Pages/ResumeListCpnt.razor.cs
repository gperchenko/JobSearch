using JobSearch.UIModels;
using JobSearch.DBModels;


namespace JobSearch.Pages
{
    public  partial class ResumeListCpnt : IDisposable
    {
        private List<Resume> resumes = new List<Resume>();
        
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
                resumes = await JobSearchService.GetResumesAsync(PageState.Profile.Id);
            }          
        }

        public void Dispose()
        {
            PageState.OnChange -= ReloadComponentAsync;
            PageState.ShowForm = false;
        }
    }
}
