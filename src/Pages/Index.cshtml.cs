using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cohackapp.Models;
using Microsoft.Extensions.Options;

namespace cohackapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public CoHackAppSettings Settings { get; }

    public IndexModel(IOptionsSnapshot<CoHackAppSettings> options, ILogger<IndexModel> logger)
    {
        Settings = options.Value;
        _logger = logger;
    }
    public void OnGet()
    {

    }
}
