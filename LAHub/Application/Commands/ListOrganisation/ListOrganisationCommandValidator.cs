using FluentValidation;

namespace Application.Commands.ListOrganisation;

public class ListOrganisationCommandValidator : AbstractValidator<ListOrganisationCommand>
{
    public ListOrganisationCommandValidator()
    {
        RuleFor(v => v.TenantId)
            .NotNull();
    }
}
