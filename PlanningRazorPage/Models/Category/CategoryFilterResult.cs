using PlanningRazorPage.Models.Blog;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlanningRazorPage.Models.Category
{
    public class CategoryFilterParam : BaseFilterParam
    {
        public string? Search { get; set; }
    }
    public class CategoryFilterResult : BaseFilter<CategoryDto, CategoryFilterParam>
    {
    }
    public static class MapCategoryDtoFilterResult
    {

        public static async Task<CategoryFilterResult> MapCategoryDtoFilter
            (this List<CategoryDto> categoryDtos, CategoryFilterParam param, CancellationToken cancellationToken)
        {
            var @params = param;
            var result = categoryDtos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(@params.Search))
            {
                result = categoryDtos.Where(i => i.Title.Contains(@params.Search)).AsQueryable();
            }


            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CategoryFilterResult()
            {
                Data = result.Skip(skip).Take(@params.Take).Select(s => new CategoryDto
                {
                    CreationDate = s.CreationDate,
                    SeoData = s.SeoData,
                    Id = s.Id,
                    Slug = s.Slug,
                    Title = s.Title,
                }).ToList(),
                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
