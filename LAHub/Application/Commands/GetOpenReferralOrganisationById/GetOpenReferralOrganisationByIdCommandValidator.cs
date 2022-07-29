using Application.Commands.GetOpenReferralOrganisationById;
using FluentValidation;

namespace Application.Commands.GetOrganisationById;
public class GetOpenReferralOrganisationByIdCommandValidator : AbstractValidator<GetOpenReferralOrganisationByIdCommand>
{
    public GetOpenReferralOrganisationByIdCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
            .NotEmpty();
    }
}