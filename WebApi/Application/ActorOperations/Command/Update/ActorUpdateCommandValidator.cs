using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi.Application.ActorOperations.Command.Update
{
    public class ActorUpdateCommandValidator : AbstractValidator<ActorUpdateCommand>
    {
        public ActorUpdateCommandValidator()
        {
            Regex regex = new Regex("^[a-zA-Z0-9]*$");

            RuleFor(command => command.Model.Name).NotEmpty();//.Matches(regex).WithMessage("Sadece harf girin.");
            RuleFor(command => command.Model.Surname).NotEmpty();//.Matches(regex).WithMessage("Sadece harf girin.");
            RuleForEach(command => command.Model.PlayedMovieIds).GreaterThan(0);
        }
    }
}
