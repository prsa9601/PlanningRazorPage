namespace PlanningRazorPage.Models.Category
{
    public record class CreateCategoryCommand(string Title, string Slug, SeoData SeoData);

    public record class EditCategoryCommand(long CategoryId, string Title,
    SeoData SeoData, string Slug);
    public record class RemoveCategoryCommand(long CategoryId);

}
