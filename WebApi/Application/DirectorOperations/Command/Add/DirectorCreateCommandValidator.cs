using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.DirectorOperations.Command.Add
{
    public class DirectorCreateCommandValidator : AbstractValidator<DirectorCreateCommand>
    {
        public DirectorCreateCommandValidator()
        {
            RuleFor(c => c.Model.Name).NotEmpty();
            RuleFor(c => c.Model.Surname).NotEmpty();
            RuleForEach(c => c.Model.DirectedMoviesId).GreaterThan(0);
        }
    }
}
