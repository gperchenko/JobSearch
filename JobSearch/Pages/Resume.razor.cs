using JobSearch.UIModels;
using JobSearch.DBModels;


namespace JobSearch.Pages
{
    public  partial class Resume : IDisposable
    {
        private List<Resume> resumes = new List<Resume>();
        private ResumeUI newResume = new ResumeUI();

        private async Task AddResume()
        {
            var resume = new Resume() 
            { 
                
            };
        }

        protected override void OnInitialized()
        {           
            PageState.OnChange += ReloadComponent;         
        }

        private async void ReloadComponent()
        {
            // InvokeAsync is inherited, it syncs the call back to the render thread
            await InvokeAsync(() => {
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            PageState.OnChange -= ReloadComponent;
        }
    }
}
