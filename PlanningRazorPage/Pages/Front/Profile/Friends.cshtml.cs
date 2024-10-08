using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Services.Friend;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class FriendsModel : PageModel
    {
        private readonly IFriendService _service;

        public FriendsModel(IFriendService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
        }
    }
}
