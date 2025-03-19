using System.Security;
using Microsoft.AspNetCore.Identity;
using PlanningRazorPage.Infrastructure;
using PlanningRazorPage.Models;

namespace PlanningRazorPage.Models.Role
{
    public class RoleDto : IdentityRole
    {
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
    }
    public class RoleFilterData : IdentityRole
    {
        //public DateTime CreationDate { get; set; }
        //public string Id { get; set; }
        public string Name { get; set; }
        public List<Permission> permissions { get; set; }
    }
    public class RoleFilterParam : BaseFilterParam
    {
        public string? Name { get; set; }
    }
    public class BaseFilter<TData, TParam> : BaseFilter
        where TParam : BaseFilterParam
        where TData : IdentityRole
    {
        public List<TData> Data { get; set; }
        public TParam FilterParams { get; set; }
    }
    public class RoleFilterResult : BaseFilter<RoleFilterData, RoleFilterParam>
    {
    }


}