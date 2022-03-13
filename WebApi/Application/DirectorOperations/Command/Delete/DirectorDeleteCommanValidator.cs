using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.DirectorOperations.Command.Delete
{
    public class DirectorDeleteCommanValidator : AbstractValidator<DirectorDeleteCommand>
    {
        public DirectorDeleteCommanValidator()
        {
            RuleFor(c => c.ModelId).NotEmpty().GreaterThan(0);
        }
    }
}
