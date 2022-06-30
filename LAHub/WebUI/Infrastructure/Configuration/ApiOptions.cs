namespace WebUI.Infrastructure.Configuration;

public class ApiOptions
{
    public const string ApplicationServiceApi = "ApplicationServiceApi";

    public string ApiBaseUrl { get; set; } = "https://localhost:7177/";
    public string SubscriptionKey { get; set; } = default!;
    public string ApiVersion { get; set; } = default!;
}
