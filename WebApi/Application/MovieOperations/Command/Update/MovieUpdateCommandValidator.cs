using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.MovieOperations.Command.Update
{
    public class MovieUpdateCommandValidator :AbstractValidator<MovieUpdateCommand>
    {
        public MovieUpdateCommandValidator()
        {
            RuleFor(command => command.UpdateModel.MovieName).NotNull().MaximumLength(1).MaximumLength(100);
            RuleFor(command => command.UpdateModel.Price).NotNull().GreaterThan(0);
            RuleFor(command => command.UpdateModel.Year).NotNull().GreaterThan(1896).LessThan(DateTime.Now.Year);
            RuleFor(command => command.UpdateModel.MovieTypeId).NotNull().GreaterThan(0);
            RuleFor(command => command.UpdateModel.DirectorId).NotNull().GreaterThan(0);
            RuleForEach(command => command.UpdateModel.MovieActorsId).GreaterThan(0).NotNull();
            RuleFor(command => command.ModelId).GreaterThan(0).NotNull();
        }
    }
}
