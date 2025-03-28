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
        public void OnPost()
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
        //public async Task<IActionResult> OnPostAddFriend()
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
        //        return _service.AddFriend("k");

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
          var  result = await _service.AddFriend(FriendUserName);
                return await AjaxTryCatch(result, true, true);
        }
        public async Task<IActionResult> OnPostRemoveFriend(string friendUserName)
        {
            return await AjaxTryCatch(() =>
            {
                //return _service.AddFriend(FriendUserName);
                return _service.RemoveFriend(friendUserName);

            }, true, true);

        }
        public async Task<IActionResult> OnPostRemoveRequest(string FriendUserName)
        {
            //var result = await _requestService.AddRequest(FriendUserName);
            //if (!result.IsSuccess)
            //{
            //    return RedirectAndShowAlert(result, Redirect("Friend"));
            //}
            //return RedirectAndShowAlert(result, Redirect("Friend"));
            //return await AjaxTryCatch(() =>
            //{
            //    //return _service.AddFriend(FriendUserName);
            //    return _requestService.DeleteRequest(FriendUserName);

            //}, true, true);

            var result = await _requestService.DeleteRequest(FriendUserName);
            return await AjaxTryCatch(result, true, true);
        }
    }
}
