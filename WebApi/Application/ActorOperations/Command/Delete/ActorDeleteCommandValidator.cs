using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.ActorOperations.Command.Delete
{
    public class ActorDeleteCommandValidator : AbstractValidator<ActorDeleteCommand>
    {
        public ActorDeleteCommandValidator()
        {
            RuleFor(command => command.ModelId).GreaterThan(0).NotEmpty();
        }
    }
}
