using JobSearch.DBModels;
using JobSearch.UIModels;

namespace JobSearch.Pages
{
    public partial class ContactListCpnt : IDisposable
    {
        private List<Contact> contacts = new List<Contact>();
       
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
                contacts = await JobSearchService.GetContactsAsync(PageState.Profile.Id);
            }
        }

        public void Dispose()
        {
            PageState.OnChange -= ReloadComponentAsync;
            PageState.ShowForm = false;
        }
    }
}
