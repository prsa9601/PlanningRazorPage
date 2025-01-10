using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Friend;
using PlanningRazorPage.Services.Request;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class SetFriendModel : BaseRazorPage
    {
        private readonly IFriendService _service;
        private readonly IRequestService _requestService;

        public SetFriendModel(IFriendService service, IRequestService requestService)
        {
            _requestService = requestService;
            _service = service;
        }

        public void OnGet()
        {
        }
        //public async Task<IActionResult> OnPostAddFriends(string FriendUserName)
        //{
        //    //var result = await _requestService.AddRequest(FriendUserName);
        //    //if (!result.IsSuccess)
        //    //{
        //    //    return RedirectAndShowAlert(result, Redirect("Friend"));
        //    //}
        //    //return RedirectAndShowAlert(result, Redirect("Friend"));
        //    return await AjaxTryCatch(() =>
        //    {
        //        //return _service.AddFriend(FriendUserName);
        //        return _requestService.AddRequest(FriendUserName);

        //    }, true, true);
        //}
        public async Task<IActionResult> OnPostAddFriend(string FriendUserName)
        {
            //var result = await _requestService.AddRequest(FriendUserName);
            //if (!result.IsSuccess)
            //{
            //    return RedirectAndShowAlert(result, Redirect("Friend"));
            //}
            //return RedirectAndShowAlert(result, Redirect("Friend"));
            return await AjaxTryCatch(() =>
            {
                //return _service.AddFriend(FriendUserName);
                return _service.AddFriend(FriendUserName);

            }, true, true);
        }
        public async Task<IActionResult> OnPostRemoveRequest(string friendUserName)
        {
            return await AjaxTryCatch(() =>
            {
                //return _service.AddFriend(FriendUserName);
                return _requestService.DeleteRequest(friendUserName);

            }, true, true);

        }

    }
}
