using Application.Commands.GetServiceById;
using Application.Commands.GetServices;
using Application.Commands.TestCommand;
using Application.Common.Models;
using Application.Models;
using LAHub.Domain.Entities;
using SFA.DAS.HashingService;
using System.Text;
using System.Text.Json;

namespace WebUI.Services.Api;

public interface ILocalOfferClientService
{
    Task<PaginatedList<ServiceItem>> GetLocalOffers(double latitude, double logtitude, double meters);
    Task<PaginatedList<TestItem>> GetTestCommand(double latitude, double logtitude, double meters);
    Task<Service> GetLocalOfferById(Guid id);
}

public class LocalOfferClientService : ApiService, ILocalOfferClientService
{
    public LocalOfferClientService(HttpClient client, IHashingService hashingService)
        : base(client, hashingService)
    {
        
    }

    public async Task<PaginatedList<ServiceItem>> GetLocalOffers(double latitude, double logtitude, double meters)
    {
        GetServicesByDistanceCommand command = new(latitude, logtitude, meters);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/GetServicesByDistanceDepricated"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<PaginatedList<ServiceItem>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.
        
    }

    public async Task<Service> GetLocalOfferById(Guid id)
    {
        GetServiceByIdCommand command = new(id);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + GetServiceByIdCommand.BuildRoute(id)),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<Service>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }

    public async Task<PaginatedList<TestItem>> GetTestCommand(double latitude, double logtitude, double meters)
    {
        GetServicesByDistanceCommand command = new(latitude, logtitude, meters);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/GetTestCommandDepricated"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<PaginatedList<TestItem>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }
}
