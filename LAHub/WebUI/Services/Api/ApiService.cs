using SFA.DAS.HashingService;

namespace WebUI.Services.Api;

public class ApiService : IApiService
{
    private readonly HttpClient _client;
    private readonly IHashingService _hashingService;

    public ApiService(HttpClient client, IHashingService hashingService)
    {
        _client = client;
        _hashingService = hashingService;
    }
}
