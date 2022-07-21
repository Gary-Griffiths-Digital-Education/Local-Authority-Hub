using Application.Commands.ListOrganisation;
using Application.Commands.ListOrganisationType;
using Application.Commands.ListTenant;
using SFA.DAS.HashingService;
using System.Text;
using System.Text.Json;

namespace WebUI.Services.Api;


public interface IOrganisationAdminClientService
{
    Task<List<TenantRecord>> GetTenantList();
    Task<List<OrganisationTypeRecord>> GetOrganisationTypeList();
    Task<List<OrganisationRecord>> GetOrganisations(Guid tenantId, Guid? organisationTypeId);
}

public class OrganisationAdminClientService : ApiService, IOrganisationAdminClientService
{
    public OrganisationAdminClientService(HttpClient client, IHashingService hashingService)
    : base(client, hashingService)
    {

    }

    public async Task<List<TenantRecord>> GetTenantList()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + "api/ListTenants"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<List<TenantRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }

    public async Task<List<OrganisationTypeRecord>> GetOrganisationTypeList()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + "api/ListOrganisationTypes"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<List<OrganisationTypeRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }

    public async Task<List<OrganisationRecord>> GetOrganisations(Guid tenantId, Guid? organisationTypeId)
    {
        ListOrganisationCommand command = new(tenantId, organisationTypeId);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/ListOrganisations"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<List<OrganisationRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }
}


