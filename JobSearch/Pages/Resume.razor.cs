using System.Net.NetworkInformation;

namespace JobSearch.Pages
{
    public  partial class Resume : IDisposable
    {
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
