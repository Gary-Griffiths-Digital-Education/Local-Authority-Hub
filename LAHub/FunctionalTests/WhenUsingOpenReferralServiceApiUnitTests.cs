using Application.Common.Models;
using FluentAssertions;
using Infrastructure.Persistence.SeedData.Organisations;
using LAHub.Domain.OpenReferralEnities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace FunctionalTests;

[Collection("Sequential")]
public class WhenUsingOpenReferralServiceApiUnitTests : BaseWhenUsingOpenReferralApiUnitTests
{
    [Fact]
    public async Task ThenByDistanceTheOpenReferralServicesAreRetrieved()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + "api/services?latitude=52.6312&longtitude=-1.66526&proximity=1609.34&pageNumber=1&pageSize=10"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();


        var retVal = await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceRecord>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var item = retVal?.Items.FirstOrDefault(x => x.Id == "4591d551-0d6a-4c0d-b109-002e67318231");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        item.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        item.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }
}
