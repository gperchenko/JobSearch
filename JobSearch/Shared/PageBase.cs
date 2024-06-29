using Microsoft.AspNetCore.Components;

namespace JobSearch.Shared
{
    public class PageBase : ComponentBase
    {
        [Inject]
        required public ProfileState ProfileState { get; init; }
    }
}
