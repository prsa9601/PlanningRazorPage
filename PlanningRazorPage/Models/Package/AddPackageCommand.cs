namespace PlanningRazorPage.Models.Package
{
    public class AddPackageCommand
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public IFormFile Picture { get; set; }
        public Dictionary<string, string> Specifications { get; set; }

    }

    public class RemovePackageCommand
    {
        public long id { get; set; }
    }
    public class RemoveActivePackageCommand
    {
        public long Id { get; set; }
    }
    public class SetActivePackageCommand
    {
        public required long Id { get; set; }
    }

    public class EditPackageCommand
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public long Id { get; set; }
        public IFormFile? Picture { get; set; }
        public Dictionary<string, string> Specifications { get; set; }

    }
    public class SetImagePackageCommand
    {
        public long Id { get; set; }
        public IFormFile Picture { get; set; }
    }

    public class SetSpecificationPackageCommand
    {
        public long id { get; set; }
        public Dictionary<string, string> Specifications { get; set; }

    }
}
