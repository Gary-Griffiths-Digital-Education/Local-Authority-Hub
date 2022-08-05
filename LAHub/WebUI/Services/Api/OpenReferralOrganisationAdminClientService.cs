using Application.Common.Models;
using LAHub.Domain.RecordEntities;
using SFA.DAS.HashingService;
using System.Text.Json;

namespace WebUI.Services.Api;

public interface IOpenReferralOrganisationAdminClientService
{
    Task<PaginatedList<OpenReferralTaxonomyRecord>> GetTaxonomyList();
    Task<List<OpenReferralOrganisationRecord>> GetListOpenReferralOrganisations();
    Task<OpenReferralOrganisationWithServicesRecord> GetOpenReferralOrganisationById(string id);
}

public class OpenReferralOrganisationAdminClientService : ApiService, IOpenReferralOrganisationAdminClientService
{
    public OpenReferralOrganisationAdminClientService(HttpClient client, IHashingService hashingService)
    : base(client, hashingService)
    {

    }

    public async Task<PaginatedList<OpenReferralTaxonomyRecord>> GetTaxonomyList()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + "api/taxonomies?pageNumber=1&pageSize=10"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralTaxonomyRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new PaginatedList<OpenReferralTaxonomyRecord>();

    }

    public async Task<List<OpenReferralOrganisationRecord>> GetListOpenReferralOrganisations()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + "api/organizations"),

        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<List<OpenReferralOrganisationRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<OpenReferralOrganisationRecord>();

    }

    public async Task<OpenReferralOrganisationWithServicesRecord> GetOpenReferralOrganisationById(string id)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/organizations/{id}"),

        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();


        return await JsonSerializer.DeserializeAsync<OpenReferralOrganisationWithServicesRecord>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new OpenReferralOrganisationWithServicesRecord(
            Guid.NewGuid().ToString()
            , ""
            , null
            , null
            , null
            , null
            , null
            );
    }
}
