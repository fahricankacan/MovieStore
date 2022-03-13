using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.DirectorOperations.Command.Update
{
    public class DirectorUpdateCommandValidator : AbstractValidator<DirectorUpdateCommand>
    {
        public DirectorUpdateCommandValidator()
        {
            RuleFor(c => c.ModelId).GreaterThan(0).NotEmpty();
            RuleFor(c => c.Model.Name).NotEmpty();
            RuleFor(c => c.Model.Surname).NotEmpty();
            //RuleForEach(c => c.Model.DirectedMovieIds).GreaterThan(0);
        }
    }
}
