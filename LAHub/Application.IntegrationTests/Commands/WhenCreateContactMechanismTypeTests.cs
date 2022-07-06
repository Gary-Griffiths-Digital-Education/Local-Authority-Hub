using Application.Commands.CreateContactMechanismType;
using Application.Common.Exceptions;
using FluentAssertions;
using LAHub.Domain.Entities;

namespace Application.IntegrationTests.Commands;

using static Testing;

public class WhenCreateContactMechanismTypeTests : BaseTestFixture
{
    private readonly Testing _testing;
    public WhenCreateContactMechanismTypeTests()
    {
        _testing = TestHelper.CreateTesting();
    }
        
    [Fact]
    public async Task ThenShouldRequireMinimumFields()
    {
        //Arrange
        var command = new CreateContactMechanismTypeCommand(string.Empty,string.Empty);

        await FluentActions.Invoking(() =>

        SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldCreateContactMechanismType()
    {
        

        var command = new CreateContactMechanismTypeCommand("Test", "Description");

        var itemId = await SendAsync(command);

        var item = await FindAsync<ContactMechanismType>(itemId);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
        item!.Description.Should().Be(command.Description);
        //item.CreatedBy.Should().Be(userId);
        //item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        //item.LastModifiedBy.Should().Be(userId);
        //item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
