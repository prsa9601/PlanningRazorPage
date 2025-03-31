namespace PlanningRazorPage.Models.User.UserPackage
{
    // در یک کلاس استاتیک مثلاً RouteDictionaryExtensions
    public static class RouteDictionaryExtensions
    {
        public static Dictionary<string, string> ToRouteDictionary(this UsersPackagesFilterParam filter, int pageId)
        {
            var routeValues = new Dictionary<string, string>();

            //if (filter.packageId.HasValue)
            //    routeValues[nameof(filter.packageId)] = filter.packageId.Value.ToString();

            if (!string.IsNullOrEmpty(filter.phoneNumber))
                routeValues[nameof(filter.phoneNumber)] = filter.phoneNumber;

            if (!string.IsNullOrEmpty(filter.userName))
                routeValues[nameof(filter.userName)] = filter.userName;

            if (filter.search != SearchUserPackage.None)
                routeValues[nameof(filter.search)] = filter.search.ToString();
            
            if (filter.PageId > 0)
                routeValues[nameof(filter.PageId)] = pageId.ToString();

            //if (filter.Take > 0)
            //    routeValues[nameof(filter.Take)] = 8.ToString();

            if (filter.ActivePackages)
                routeValues[nameof(filter.ActivePackages)] = "true";

            if (filter.FilterStartTime != DateTime.MinValue)
                routeValues[nameof(filter.FilterStartTime)] = filter.FilterStartTime.ToString("yyyy-MM-dd");

            if (filter.FilterEndTime != DateTime.MaxValue)
                routeValues[nameof(filter.FilterEndTime)] = filter.FilterEndTime.ToString("yyyy-MM-dd");

            // اضافه کردن سایر فیلدها

            return routeValues;
        }
        public static Dictionary<string, string> ToRouteDictionary(this UsersPackagesByUserIdFilterParam filter,int pageId)
        {
            var routeValues = new Dictionary<string, string>();

            //if (filter.packageId.HasValue)
            //    routeValues[nameof(filter.packageId)] = filter.packageId.Value.ToString();
            if (!string.IsNullOrEmpty(filter.UserId))
                routeValues[nameof(filter.UserId)] = filter.UserId;

            if (filter.search != SearchUserPackage.None)
                routeValues[nameof(filter.search)] = filter.search.ToString();

            if (filter.PageId > 0)
                routeValues[nameof(filter.PageId)] = pageId.ToString();
            
            //if (filter.Take > 0)
            //    routeValues[nameof(filter.Take)] = 8.ToString();
            
            //if (filter.Take > 0)
            //    routeValues[nameof(filter.Take)] = filter.Take.ToString();

            if (filter.ActivePackages)
                routeValues[nameof(filter.ActivePackages)] = "true";

            if (filter.FilterStartTime != DateTime.MinValue)
                routeValues[nameof(filter.FilterStartTime)] = filter.FilterStartTime.ToString("yyyy-MM-dd");

            if (filter.FilterEndTime != DateTime.MaxValue)
                routeValues[nameof(filter.FilterEndTime)] = filter.FilterEndTime.ToString("yyyy-MM-dd");

            // اضافه کردن سایر فیلدها

            return routeValues;
        }
    }
}
