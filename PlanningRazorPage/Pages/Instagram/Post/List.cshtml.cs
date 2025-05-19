using Microsoft.AspNetCore.Mvc;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.SocialMedia.Instagram;
using static PlanningRazorPage.Models.SocialMedia.Instagram.Post.PostFilterData;

namespace PlanningRazorPage.Pages.Instagram.Post
{
    public class ListModel : BaseRazorFilter<InstagramPostFilterParam>
    {
        private readonly IInstagramService _service;

        public ListModel(IInstagramService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public InstagramPostFilterResult PostResult { get; set; }
        [BindProperty]
        public long InstagramId { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public PostDto? Result { get; set; }
        public async Task<IActionResult> OnGet(long accountId)
        {
         
            PostResult = await _service.GetPostByFilter(new InstagramPostFilterParam
            {
                InstagramId = accountId,
                PageId = FilterParams.PageId,
                Take = 8,
                Search = FilterParams.Search,
                SearchOrderBy = FilterParams.SearchOrderBy
            });
            InstagramId = accountId;
            //Result = PostResult.Data.FirstOrDefault(i => i.InstagramUserName.Equals(InstagramId));
            return Page();
        }
    }
}
