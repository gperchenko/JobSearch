using JobSearch.Services;
using Microsoft.AspNetCore.Components;

namespace JobSearch.Shared
{
    public class PageBase : ComponentBase
    {
        [Inject]
        required public IJobSearchService JobSearchService { get; init; }

        [Inject]
        required public PageState PageState { get; init; }
    }
}
