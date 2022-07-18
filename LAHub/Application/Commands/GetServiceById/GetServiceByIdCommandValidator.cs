using FluentValidation;

namespace Application.Commands.GetServiceById;

public class GetServiceByIdCommandValidator : AbstractValidator<GetServiceByIdCommand>
{
    public GetServiceByIdCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
            .NotEmpty();
    }
}
