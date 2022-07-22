using FluentValidation;

namespace Application.Commands.UpdateOrganisation;
public class UpdateOrganisationCommandValidator : AbstractValidator<UpdateOrganisationCommand>
{
    public UpdateOrganisationCommandValidator()
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

