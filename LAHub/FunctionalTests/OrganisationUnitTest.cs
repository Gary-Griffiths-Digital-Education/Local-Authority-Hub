using WebAPI.Endpoints;

namespace FunctionalTests;

[Collection("Sequential")]
public class OrganisationUnitTest : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
    private readonly HttpClient _client;

    public OrganisationUnitTest(CustomWebApplicationFactory<WebMarker> factory)
    {
        _client = factory.CreateClient();
    }

    
    [Fact]
    public async Task ReturnsVersionAndLastUpdateDate()
    {
        var response = await _client.GetAsync("/info");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();

        Assert.Contains("Version", stringResponse);
        Assert.Contains("Last Updated", stringResponse);
    }
    

    //[Fact]
    //public void Test1()
    //{

    //}
}