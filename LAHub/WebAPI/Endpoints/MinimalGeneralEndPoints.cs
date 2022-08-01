using System.Diagnostics;

namespace WebAPI.Endpoints;

public class MinimalGeneralEndPoints
{
    public void RegisterMinimalGeneralEndPoints(WebApplication app)
    {
        app.MapGet("api/info", () =>
        {
            try
            {
                var assembly = typeof(WebMarker).Assembly;

                var creationDate = System.IO.File.GetCreationTime(assembly.Location);
                var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

                return Results.Ok($"Version: {version}, Last Updated: {creationDate}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        });
    }
}
