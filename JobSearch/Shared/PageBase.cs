using Microsoft.AspNetCore.Components;

namespace JobSearch.Shared
{
    public class PageBase : ComponentBase
    {
        [Inject]
        required public PageState PageState { get; init; }
    }
}
