using JobSearch.Services;
using Microsoft.AspNetCore.Components;

namespace JobSearch.Shared
{
    public class PageState
    {     
        public DBModels.Profile Profile { get; set; }
        public event Action? OnChange;
        public bool ShowForm { get; set; } = false;

        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
