namespace PlanningRazorPage.Models.Package
{
    public class PackageDto : BaseDto
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Link { get; set; }
        public int Price { get; set; }
        public List<PackageSpecificationDto?> Specification { get; set; } = new List<PackageSpecificationDto?>();
        public bool Active { get; set; } = false;

    }
    public class ActivePackagesDto : BaseDto
    {
        public long PackageId { get; set; }

    }

    public class PackageSpecificationDto : BaseDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public long PackageId { get; set; }
    }
}
