using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.Queries.GetMovieById
{
    public class GetMovieByIdQueryValidator : AbstractValidator<GetMoviesByIdQuery>
    {
        public GetMovieByIdQueryValidator()
        {
            RuleFor(commmand => commmand.MovieId).GreaterThan(0);
        }
    }
}
