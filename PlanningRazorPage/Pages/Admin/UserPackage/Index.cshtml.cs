using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models.User.UserPackage;
using PlanningRazorPage.Services.User;
using PlanningRazorPage.Services.User.UserPackage;
using System.Diagnostics;
using System.Globalization;

namespace PlanningRazorPage.Pages.Admin.UserPackage
{
    public class IndexModel : BaseRazorFilter<UsersPackagesFilterParamViewModel>
    {
        private readonly IUserPackageService _service;

        public IndexModel(IUserPackageService service)
        {
            _service = service;
        }

        public UsersPackagesFilterResult? Users { get; set; }
        public async Task<IActionResult> OnGet(int pageId = 1, int take = 8, bool activePackage = false,
            string? filterStartTime = null, string? filterEndTime = null)
        {

            Users = await _service.GetFilterUserPackages(new UsersPackagesFilterParam
            {
                //packageId = pageId,
                packageTitle = FilterParams.packageTitle,
                Take = take,
                PageId = pageId,
                phoneNumber = FilterParams.phoneNumber,
                search = FilterParams.search,
                userName = FilterParams.userName,
                ActivePackages = activePackage,
                FilterEndTime = ConvertPersianDateToDateTime(FilterParams.FilterEndTime),
                FilterStartTime = ConvertPersianDateToDateTime(FilterParams.FilterStartTime)
                //FilterEndTime = filterEndTime.ToMiladi() ?? DateTime.MaxValue,
                //FilterStartTime = filterStartTime.ToMiladi() ?? DateTime.MinValue
            });
            return Page();
        }
        public DateTime ConvertPersianDateToDateTime(string persianDate)
        {
            if (persianDate == null)
                return DateTime.MinValue;
            // جدا کردن اجزای تاریخ
            var parts = persianDate.Split('/');
            if (parts.Length != 3)
                throw new FormatException("تاریخ ورودی باید در فرمت 'yyyy/MM/dd' باشد.");

            // تبدیل اعداد فارسی به انگلیسی
            int year = ConvertPersianNumberToEnglish(parts[0]);
            int month = ConvertPersianNumberToEnglish(parts[1]);
            int day = ConvertPersianNumberToEnglish(parts[2]);

            // استفاده از PersianCalendar برای تبدیل تاریخ
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

            return gregorianDate;
        }

        private int ConvertPersianNumberToEnglish(string persianNumber)
        {
            // تعریف اعداد فارسی و معادل‌های انگلیسی آن‌ها
            var persianNumbers = new[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            var englishNumbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            // تبدیل اعداد فارسی به انگلیسی
            for (int i = 0; i < persianNumbers.Length; i++)
            {
                persianNumber = persianNumber.Replace(persianNumbers[i], englishNumbers[i]);
            }

            // تبدیل به عدد صحیح
            return int.Parse(persianNumber);
        }
    }
}

