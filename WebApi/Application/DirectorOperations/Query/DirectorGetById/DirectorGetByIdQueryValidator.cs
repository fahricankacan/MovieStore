using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.DirectorOperations.Query.DirectorGetById
{
    public class DirectorGetByIdQueryValidator : AbstractValidator<DirectorGetByIdQuery>
    {
        public DirectorGetByIdQueryValidator()
        {
            RuleFor(c => c.ModelId).GreaterThan(0).NotEmpty();
        }
    }
}
