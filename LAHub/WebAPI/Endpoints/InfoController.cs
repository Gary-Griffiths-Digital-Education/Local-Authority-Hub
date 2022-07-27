using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebAPI.Endpoints;

/// <summary>
/// If your API controllers will use a consistent route convention and the [ApiController] attribute (they should)
/// then it's a good idea to define and use a common base controller class like this one.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : Controller
{
}

public class InfoController : BaseApiController
{
    /// <summary>
    /// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
    /// https://github.com/ardalis/ApiEndpoints
    /// </summary>
    [HttpGet("/info")]
    public ActionResult<string> Info()
    {
        var assembly = typeof(WebMarker).Assembly;

        var creationDate = System.IO.File.GetCreationTime(assembly.Location);
        var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

        return Ok($"Version: {version}, Last Updated: {creationDate}");
    }
}
