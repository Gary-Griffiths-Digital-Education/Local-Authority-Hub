using FluentValidation;

namespace Application.Commands.GetOpenReferralService;

public class GetOpenReferralServiceByIdCommandValidator : AbstractValidator<GetOpenReferralServiceByIdCommand>
{
    public GetOpenReferralServiceByIdCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
            .NotEmpty();
    }
}
