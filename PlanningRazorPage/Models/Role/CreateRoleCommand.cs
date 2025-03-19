using PlanningRazorPage.Infrastructure;

namespace PlanningRazorPage.Models.Role
{
    public class CreateRoleCommand
    {
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
    }
    public record class DeleteRoleCommand(long roleId);
    public class EditRoleCommand
    {
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
        public string Id { get; set; }
    }


}
