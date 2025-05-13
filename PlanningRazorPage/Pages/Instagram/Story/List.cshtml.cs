using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using PlanningRazorPage.Services.SocialMedia.Instagram;

namespace PlanningRazorPage.Pages.Instagram.Story
{
    public class ListModel : BaseRazorFilter<StoryFilterParam>
    {
        private readonly IInstagramService _service;

        public ListModel(IInstagramService service)
        {
            _service = service;
        }

        [BindProperty]
        public StoryDto? StoryDto { get; set; }
        [BindProperty(SupportsGet = true)]
        public StoryFilterResult FilterResult { get; set; }

        public async Task<IActionResult> OnGet(long accountId)
        {
            if (FilterParams.InstagramId == 0)
            {

                FilterParams.InstagramId = accountId;
            }
            FilterResult = await _service.GetStoryByFilter(new StoryFilterParam
            {
                InstagramId = FilterParams.InstagramId,
                PageId = FilterParams.PageId,
                Search = FilterParams.Search,
                SearchOrderBy = FilterParams.SearchOrderBy,
                Take = 8
            });
            //StoryDto = FilterResult.Data.FirstOrDefault(i=>i.InstagramId.Equals());
            return Page();
        }
    }
}
