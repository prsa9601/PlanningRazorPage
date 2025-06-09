using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Models;

namespace PlanningRazorPage.Infrastructure.RazorUtils;

public class BaseRazorFilter<TFilterParam> : BaseRazorPage where TFilterParam : BaseFilterParam 
{
    [BindProperty(SupportsGet = true)]
    public TFilterParam FilterParams { get; set; }
}