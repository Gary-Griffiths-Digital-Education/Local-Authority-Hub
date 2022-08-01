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


    Task<Guid> CreateOrganisation(
        Guid tenantId,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        Guid organisationTypeId,
        string contactName,
        string contactEmail,
        ICollection<Service> services);

    Task<Guid> UpdateOrganisation(
        Guid id,
        Guid tenantId,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        Guid organisationTypeId,
        Guid contactId,
        string contactName,
        string contactEmail,
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
            RequestUri = new Uri(_client.BaseAddress + "api/ListTenantsDepricated"),
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
            RequestUri = new Uri(_client.BaseAddress + "api/ListOrganisationTypesDepricated"),
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
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + ListOrganisationCommand.BuildRoute(tenantId, organisationTypeId != null ? organisationTypeId : Guid.Empty)),
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
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + GetOrganisationByIdCommand.BuildRoute(id)),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<Organisation>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }

    public async Task<Guid> CreateOrganisation(
        Guid tenantId,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        Guid organisationTypeId,
        string contactName,
        string contactEmail,
        ICollection<Service> services)
    {
        CreateOrganisationCommand command = new(
        tenantId,
        name,
        description,
        logoUrl,
        logoAltText,
        organisationTypeId,
        contactName,
        contactEmail,
        services
        );

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/CreateMyOrganisationDepricated"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }

    
    public async Task<Guid> UpdateOrganisation(
        Guid id,
        Guid tenantId,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        Guid organisationTypeId,
        Guid contactId,
        string contactName,
        string contactEmail,
        ICollection<Service> services)
    { 
        
        UpdateOrganisationCommand command = new(
        id,
        tenantId,
        name,
        description,
        logoUrl,
        logoAltText,
        organisationTypeId,
        contactId,
        contactName,
        contactEmail,
        services
        );

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(_client.BaseAddress + "api/UpdateOrganisationDepricated"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
        return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

    }
}


