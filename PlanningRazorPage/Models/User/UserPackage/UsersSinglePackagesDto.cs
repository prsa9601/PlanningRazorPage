namespace PlanningRazorPage.Models.User.UserPackage
{
    public class UsersSinglePackagesDto : BaseDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public UserSinglePackageDto userPackages { get; set; }
    }
    public class UserPackageDto : BaseDto
    {
        public long PackageId { get; set; }
        public string UserId { get; set; }
        public int AllowedEmailCount { get; set; } = 10;
        public int AllowedSmsCount { get; set; } = 0;
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class UsersPackagesDto : BaseDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<UserPackageDto> userPackages { get; set; }

    }
    public class UserSinglePackageDto : BaseDto
    {
        //public string UserName { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Email { get; set; }
        public long PackageId { get; set; }
        public string UserId { get; set; }
        public int AllowedEmailCount { get; set; } = 10;
        public int AllowedSmsCount { get; set; } = 0;
        public TimeSpan ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class UsersPackagesFilterParamViewModel : BaseFilterParam
    {
        //public long? packageId { get; set; }
        public string? packageTitle { get; set; }
        public bool ActivePackages { get; set; }
        public string? phoneNumber { get; set; }
        public string? FilterStartTime { get; set; } = null;
        public string? FilterEndTime { get; set; } = null;
        public SearchUserPackage search { get; set; } 
        public string? userName { get; set; }
    }
    public class UsersPackagesFilterParam : BaseFilterParam
    {
        //public long? packageId { get; set; }
        public string? packageTitle { get; set; }
        public bool ActivePackages { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime FilterStartTime { get; set; } = DateTime.MinValue;
        public DateTime FilterEndTime { get; set; } = DateTime.MaxValue;
        public SearchUserPackage search { get; set; } 
        public string? userName { get; set; }
    }
    public enum SearchUserPackage
    {
        None,
        Latest,
        //BestSeller
    }
    public class UsersPackagesFilterDataDto : BaseDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public UserPackageDto userPackages { get; set; }

    }


    public class UsersPackagesFilterResult : BaseFilter<UsersPackagesFilterDataDto, UsersPackagesFilterParam>
    {

    }
    public class UsersPackagesByUserIdFilterParam : BaseFilterParam
    {
        public string? UserId { get; set; }
        public bool ActivePackages { get; set; }
        public DateTime FilterStartTime { get; set; }
        public DateTime FilterEndTime { get; set; }
        public SearchUserPackage search { get; set; } = SearchUserPackage.None;
    }
    public class UsersPackagesByUserIdFilterResult : BaseFilter<UsersPackagesDto, UsersPackagesByUserIdFilterParam>
    {

    }

}
