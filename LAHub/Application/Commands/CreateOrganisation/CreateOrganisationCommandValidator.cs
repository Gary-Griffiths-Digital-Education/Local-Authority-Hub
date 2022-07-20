using FluentValidation;

namespace Application.Commands.CreateOrganisation;

public class CreateOrganisationCommandValidator : AbstractValidator<CreateOrganisationCommand>
{
    public CreateOrganisationCommandValidator()
    {
        RuleFor(v => v.Tenant)
            .NotNull();

        RuleFor(v => v.OrganisationType)
            .NotNull();

        RuleFor(v => v.Name)
            .MinimumLength(1)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(500);
    }
}
