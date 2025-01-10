using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Services.Friend;
using PlanningRazorPage.Services.Request;
using PlanningRazorPage.Services.User;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class FriendsModel : BaseRazorFilter<UserFriendFilterParam>
    {
        private readonly IFriendService _service;
        private readonly IUserService _userService;
        private readonly IRequestService _requestService;

        public FriendsModel(IFriendService service, IUserService userService, IRequestService requestService)
        {
            _requestService = requestService;
            _service = service;
            _userService = userService;
        }
        //[BindProperty]
        //public string? userName { get; set; }
        [BindProperty(SupportsGet = true)]
        public UserFriendFilterResultViewModel? Friends { get; set; }

        public async Task OnGet()
        {
            //await Task.Delay(1000);

            var result = await _service.GetListFriendsByUserIdForProfile(new UserFriendFilterParam()
            {
                PageId = FilterParams.PageId,
                Take = FilterParams.Take,
                UserName = FilterParams.UserName
            });
            if (result.Data != null && result.Data.Count() != 0)
            {
                Friends = Map(result);
            }
        }
        public async Task OnGetSearch(string userName, int pageId = 1, int take = 8)
        {
            var result = await _service.GetListFriendsByUserIdForProfile(new UserFriendFilterParam()
            {
                PageId = pageId,
                Take = take,
                UserName = userName
            });
            if (result.Data != null && result.Data.Count() != 0)
            {
                Friends = Map(result);
            }
        }

        public async Task<IActionResult> OnPostAddFriends(string FriendUserName, int PageId = 1,int take = 10)
        {
            //var result = await _requestService.AddRequest(FriendUserName);
            //if (!result.IsSuccess)
            //{
            //    return RedirectAndShowAlert(result, Redirect("Friend"));
            //}
            //    //HttpContext.Response.Headers.Add("Refresh", "0");
            //return RedirectAndShowAlert(result, Redirect("Friend"));
            //HttpContext.Response.Headers.Add("Refresh", "0");

            FilterParams.PageId = PageId; FilterParams.Take = take;
            return await AjaxTryCatch(() =>
            {
                //return _service.AddFriend(FriendUserName);
                return _requestService.AddRequest(FriendUserName);

            }, true, true);
        }

        ///images/users/avatar/
        internal UserFriendFilterResultViewModel? Map(UserFriendFilterResult? command)
        {
            var model = new UserFriendFilterResultViewModel();
            var friendDtoViewModel = new List<FriendDtoViewModel>();
            foreach (var item in command.Data)
            {
                StringBuilder stringBuilder = new StringBuilder();
                switch (item.avatar.Avatar)
                {
                    case Avatar.Man:
                        stringBuilder.Append("Man.png");
                        break;
                    case Avatar.Woman:
                        stringBuilder.Append("Woman.png");
                        break;
                    case Avatar.Boy:
                        stringBuilder.Append("Boy.png");
                        break;
                    case Avatar.Girl:
                        stringBuilder.Append("Girl.png");
                        break;
                    default:
                        stringBuilder.Append("Default.png");
                        break;

                }

                friendDtoViewModel.Add(new FriendDtoViewModel()
                {
                    CreationDate = item.CreationDate,
                    FriendId = item.FriendId,
                    //FriendUrl = item.FriendUrl,
                    FriendUserName = item.FriendUserName,
                    Id = item.Id,
                    UserId = item.UserId,
                    avatar = stringBuilder.ToString(),
                    IsSendRequest = item.IsSendRequest,
                    IsFriend = item.IsFriend

                });
                stringBuilder.Clear();
            }

            model.Data = friendDtoViewModel;
            model.FilterParams = command.FilterParams;
            model.PageCount = command.PageCount;
            model.CurrentPage = command.CurrentPage;
            model.StartPage = command.StartPage;
            model.EndPage = command.EndPage;
            model.Take = command.Take;
            model.EntityCount = command.EntityCount;
            return model;
        }

        //internal static List<FriendDtoViewModel>? Map(List<FriendDto>? model)
        //{
        //    var friendDtoViewModel = new List<FriendDtoViewModel>();
        //    foreach (var item in model)
        //    {
        //        StringBuilder stringBuilder = new StringBuilder();
        //        switch (item.avatar.Avatar)
        //        {
        //            case Avatar.Man:
        //                stringBuilder.Append("/images/users/avatar/Man");
        //                break;
        //            case Avatar.Woman:
        //                stringBuilder.Append("/images/users/avatar/Woman");
        //                break;
        //            case Avatar.Boy:
        //                stringBuilder.Append("/images/users/avatar/Boy");
        //                break;
        //            case Avatar.Girl:
        //                stringBuilder.Append("/images/users/avatar/Girl");
        //                break;
        //            default:
        //                stringBuilder.Append("/images/users/avatar/Default");
        //                break;

        //        }

        //        friendDtoViewModel.Add(new FriendDtoViewModel()
        //        {
        //            CreationDate = item.CreationDate,
        //            FriendId = item.FriendId,
        //            FriendUrl = item.FriendUrl,
        //            FriendUserName = item.FriendUserName,
        //            Id = item.Id,
        //            UserId = item.UserId,
        //            avatar = stringBuilder.ToString()

        //        });
        //        stringBuilder.Clear();
        //    }

        //    return friendDtoViewModel;
        //}
    }
}
