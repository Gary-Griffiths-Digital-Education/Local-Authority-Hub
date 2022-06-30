using Application.Commands.CreateContactMechanismType;
using Application.Common.Exceptions;
using FluentAssertions;

namespace Application.IntegrationTests.Commands;

using static Testing;

public class WhenCreateContactMechanismTypeTests : BaseTestFixture
{
    private readonly Testing _testing;
    public WhenCreateContactMechanismTypeTests()
    {
        _testing = new Testing();
        _testing.RunBeforeAnyTests();
        //Task.Run(() => Testing.ResetState()).Wait();
    }
        
    [Fact]
    public async Task ThenShouldRequireMinimumFields()
    {
        //Arrange
        var command = new CreateContactMechanismTypeCommand(string.Empty,string.Empty);

        await FluentActions.Invoking(() =>

        SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
}
