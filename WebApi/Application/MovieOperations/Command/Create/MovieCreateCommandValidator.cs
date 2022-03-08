using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Command.Create
{
    public class MovieCreateCommandValidator:AbstractValidator<MovieCreateCommand>
    {
        public MovieCreateCommandValidator()
        {
            RuleFor(command => command.CreateModel.MovieName).NotNull().MaximumLength(1).MaximumLength(100);
            RuleFor(command => command.CreateModel.Price).NotNull().GreaterThan(0);
            RuleFor(command => command.CreateModel.Year).NotNull().GreaterThan(1896).LessThan(DateTime.Now.Year);          
            RuleFor(command => command.CreateModel.MovieTypeId).NotNull().GreaterThan(0);
            RuleFor(command => command.CreateModel.DirectorId).NotNull().GreaterThan(0);
            RuleForEach(command => command.CreateModel.MovieActorsId).GreaterThan(0).NotNull();

        }
    }
}
