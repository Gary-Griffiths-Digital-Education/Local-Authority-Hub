using Application.Commands.TestCommand;
using Application.Common.Models;
using LAHub.Domain.RecordEntities;
using SFA.DAS.HashingService;
using System.Text;
using System.Text.Json;

namespace WebUI.Services.Api;

public interface ILocalOfferClientService
{
    Task<PaginatedList<OpenReferralServiceRecord>> GetLocalOffers(int minimum_age, int maximum_age, double latitude, double longtitude, double proximity, int pageNumber, int pageSize, string text);
    Task<OpenReferralServiceRecord> GetLocalOfferById(string id);
    //Task<PaginatedList<TestItem>> GetTestCommand(double latitude, double logtitude, double meters);
}

public class LocalOfferClientService : ApiService, ILocalOfferClientService
{
    public LocalOfferClientService(HttpClient client, IHashingService hashingService)
        : base(client, hashingService)
    {
        
    }

    public async Task<PaginatedList<OpenReferralServiceRecord>> GetLocalOffers(int minimum_age, int maximum_age, double latitude, double longtitude, double proximity, int pageNumber, int pageSize, string text)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services?minimum_age={minimum_age}&maximum_age={maximum_age}&latitude={latitude}&longtitude={longtitude}&proximity={proximity}&pageNumber={pageNumber}&pageSize={pageSize}&text={text}"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new PaginatedList<OpenReferralServiceRecord>();
    }

    public async Task<OpenReferralServiceRecord> GetLocalOfferById(string id)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services/{id}"),

        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var retVal = await JsonSerializer.DeserializeAsync<OpenReferralServiceRecord>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        ArgumentNullException.ThrowIfNull(retVal, nameof(retVal));

        return retVal;
    }

//    public async Task<PaginatedList<TestItem>> GetTestCommand(double latitude, double logtitude, double meters)
//    {
//        GetServicesByDistanceCommand command = new(latitude, logtitude, meters);

//        var request = new HttpRequestMessage
//        {
//            Method = HttpMethod.Post,
//            RequestUri = new Uri(_client.BaseAddress + "api/GetTestCommandDepricated"),
//            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
//        };

//        using var response = await _client.SendAsync(request);

//        response.EnsureSuccessStatusCode();

//#pragma warning disable CS8603 // Possible null reference return.
//        return await JsonSerializer.DeserializeAsync<PaginatedList<TestItem>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//#pragma warning restore CS8603 // Possible null reference return.

//    }
}
