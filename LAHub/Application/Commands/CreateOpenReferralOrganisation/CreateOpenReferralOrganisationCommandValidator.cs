﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateOpenReferralOrganisation;

public class CreateOpenReferralOrganisationCommandValidator : AbstractValidator<CreateOpenReferralOrganisationCommand>
{
    public CreateOpenReferralOrganisationCommandValidator()
    {
        RuleFor(v => v.OpenReferralOrganisation)
            .NotNull();

        RuleFor(v => v.OpenReferralOrganisation.Id)
            .MinimumLength(1)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.OpenReferralOrganisation.Name)
            .MinimumLength(1)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty();
    }
}
