using AutoFixture;
using LAHub.Domain.Entities;
using OrganisationAdmin.IntegrationTests.Persistence;
using Xunit;

namespace OrganisationAdmin.IntegrationTests.Organisations.Commands;

public class CreateOrganisation : BaseEfRepositoryTestFixture
{
    private readonly Fixture _fixture;

    public CreateOrganisation()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public async Task Create()
    {
        // Arrange
        //var actual = _fixture.Create<Organisation>(); // TODO: investigate why this fails
        var actual = new Organisation();
        actual.Name = "Name";
        actual.Description = "Description";

        var organisation = new Organisation();
        organisation.Name = actual.Name;
        organisation.Description = actual.Description;

        // Act
        var repository = GetRepository();
        await repository.AddAsync(organisation);
        var persistedOrganisation = await repository.GetByIdAsync(organisation.Id);
        ArgumentNullException.ThrowIfNull(persistedOrganisation);

        // Assert
        Assert.Equal(actual.Name, persistedOrganisation.Name);
        Assert.Equal(actual.Description, persistedOrganisation.Description);
    }
}
