using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Instagram.Dto;
using PlanningRazorPage.Services.SocialMedia.Instagram;

namespace PlanningRazorPage.Pages.Instagram
{
    public class ListModel : BaseRazorFilter<InstagramAccountFilterParam>
    {
        private readonly IInstagramService _accountService;

        public ListModel(IInstagramService accountService)
        {
            _accountService = accountService;
        }

        public InstagramAccountFilterResult FilterResult { get; set; }

        [BindProperty(SupportsGet = true)]
        public InstagramAccountFilterParam FilterParams { get; set; } = new();

        public async Task OnGet()
        {
            FilterResult = await _accountService.GetFilter(FilterParams);
        }
    }
}
