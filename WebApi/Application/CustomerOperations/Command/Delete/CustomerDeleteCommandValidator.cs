using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.CustomerOperations.Command.Delete;

namespace WebApi.Application.CustomerOperations.Command.Delete
{
    public class CustomerDeleteCommandValidator : AbstractValidator<CustomerDeleteCommand>
    {
        public CustomerDeleteCommandValidator()
        {
            RuleFor(command => command.ModelId).GreaterThan(0).NotEmpty();
        }
    }
}
