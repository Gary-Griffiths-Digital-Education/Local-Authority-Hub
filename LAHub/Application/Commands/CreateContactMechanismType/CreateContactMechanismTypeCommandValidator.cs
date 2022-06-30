using FluentValidation;

namespace Application.Commands.CreateContactMechanismType;

public class CreateContactMechanismTypeCommandValidator : AbstractValidator<UpdateContactMechanismTypeCommand>
{
    public CreateContactMechanismTypeCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(500);
    }
}
