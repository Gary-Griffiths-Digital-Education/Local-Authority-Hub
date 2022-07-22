using FluentValidation;

namespace Application.Commands.GetOrganisationById;
public class GetOrganisationByIdCommandValidator : AbstractValidator<GetOrganisationByIdCommand>
{
    public GetOrganisationByIdCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
            .NotEmpty();
    }
}