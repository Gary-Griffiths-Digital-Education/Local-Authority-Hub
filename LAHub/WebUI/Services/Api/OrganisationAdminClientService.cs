using Application.Commands.CreateOrganisation;
using Application.Commands.GetOrganisationById;
using Application.Commands.ListOrganisation;
using Application.Commands.ListOrganisationType;
using Application.Commands.ListTenant;
using Application.Commands.UpdateOrganisation;
using LAHub.Domain.Entities;
using SFA.DAS.HashingService;
using System.Text;
using System.Text.Json;

namespace WebUI.Services.Api;


public interface IOrganisationAdminClientService
{
    Task<List<TenantRecord>> GetTenantList();
    Task<List<OrganisationTypeRecord>> GetOrganisationTypeList();
    Task<List<OrganisationRecord>> GetOrganisations(Guid tenantId, Guid? organisationTypeId);
    Task<Organisation> GetOrganisationById(Guid id);

    Task<List<OrganisationRecord>> CreateOrganisation(
        Tenant tenant,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        OrganisationType organisationType,
        Contact? contact,
        ICollection<Service> services);

    Task<List<OrganisationRecord>> UpdateOrganisation(
        Guid id,
        Tenant tenant,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        OrganisationType organisationType,
        Contact? contact,
        ICollection<Service> services);
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

    public async Task<Organisation> GetOrganisationById(Guid id)
    {
        GetOrganisationByIdCommand command = new(id);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/GetOrganisationById"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<Organisation>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }

    public async Task<List<OrganisationRecord>> CreateOrganisation(
        Tenant tenant,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        OrganisationType organisationType,
        Contact? contact,
        ICollection<Service> services)
    {

        CreateOrganisationCommand command = new(
        tenant,
        name,
        description,
        logoUrl,
        logoAltText,
        organisationType,
        contact,
        services
        );

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/CreateOrganisation"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<List<OrganisationRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }

    public async Task<List<OrganisationRecord>> UpdateOrganisation(
        Guid id,
        Tenant tenant,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        OrganisationType organisationType,
        Contact? contact,
        ICollection<Service> services)
    { 
        
        UpdateOrganisationCommand command = new(id,
        tenant,
        name,
        description,
        logoUrl,
        logoAltText,
        organisationType,
        contact,
        services
        );

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/UpdateOrganisation"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<List<OrganisationRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }
}


