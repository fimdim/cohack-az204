using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement.Mvc;

namespace cohackapp.Pages;

[FeatureGate("Details")]
public class DetailsModel : PageModel
{
    public void OnGet()
    {
    }
}

