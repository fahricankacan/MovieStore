using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.CustomerOperations.Command.Create
{
    public class CustomerCreateCommandValidator:AbstractValidator<CustomerCreateCommand>
    {
        public CustomerCreateCommandValidator()
        {
            RuleFor(command => command.Model.Email).NotEmpty().EmailAddress();
            RuleFor(commmand => commmand.Model.Password).NotEmpty().MinimumLength(3).MaximumLength(12);
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleForEach(command => command.Model.FavoriteMovieIds).GreaterThan(0);

        }

    }
}
