using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Infrastructure.FileUtil
{
    public class MaxFileCountAttribute : ValidationAttribute
    {
        private readonly int _maxFiles;
        public MaxFileCountAttribute(int maxFiles) => _maxFiles = maxFiles;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is IList<IFormFile> files && files.Count > _maxFiles)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }

    public class AllowedFileExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedFileExtensionsAttribute(string[] extensions) => _extensions = extensions;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is IList<IFormFile> files)
            {
                foreach (var file in files)
                {
                    var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (!_extensions.Contains(ext))
                        return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
