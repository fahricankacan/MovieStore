using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.ActorOperations.Query.GetById
{
    public class ActorGetByIdQueryValidator : AbstractValidator<ActorGetByIdQuery>
    {
        public ActorGetByIdQueryValidator()
        {
            RuleFor(command => command.ModelId).NotEmpty().GreaterThan(0);
        }
    }
}
