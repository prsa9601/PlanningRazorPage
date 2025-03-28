using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Request;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class AddRequestModel : BaseRazorPage
    {
        private readonly IRequestService _requestService;

        public AddRequestModel(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAddRequest(string FriendUserName)
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
                return _requestService.AddRequest(FriendUserName);

            }, true, true);
        }
        public async Task<IActionResult> OnPostRemoveRequestForSender(string FriendUserName)
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

            var result = await _requestService.DeleteRequestForSender(FriendUserName);
            return await AjaxTryCatch(result, true, true);
        }
    }
}
