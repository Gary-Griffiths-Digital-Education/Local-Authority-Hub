using FluentAssertions;
using Infrastructure.Persistence.SeedData.Organisations;
using LAHub.Domain.OpenReferralEnities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace FunctionalTests;

public abstract class BaseWhenUsingOpenReferralApiUnitTests
{
    protected readonly HttpClient _client;

    public BaseWhenUsingOpenReferralApiUnitTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();

        _client = webAppFactory.CreateDefaultClient();
        _client.BaseAddress = new Uri("https://localhost:7128/");
    }
}
