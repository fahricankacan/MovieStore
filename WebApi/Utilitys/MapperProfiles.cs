using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using static WebApi.Application.MovieOperations.Command.Create.MovieCreateCommandValidator;
using static WebApi.Application.Queries.GetMovies.GetMoviesQuery;

namespace WebApi.Utilitys
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Movie, MovieModel>()              
                .ForMember(dest => dest.Type, opt => opt.MapFrom(x=>x.MovieType.Type))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(x => x.Director.Name + " "+ x.Director.Surname))
                .ForMember(dest => dest.ActorNames, opt => opt
                    .MapFrom(x => x.MovieActors.Select(y => y.Actors.Name + y.Actors.Surname).ToList()));

            //CreateMap<MovieCreateModel, Movie>()
            //    .ForMember(src => src.MovieName, opt => opt.MapFrom(x => x.MovieName))
            //    .ForMember(src => src.Price, opt => opt.MapFrom(x => x.Price))
            //    .ForMember(src => src.Year, opt => opt.MapFrom(x => x.Year))
            //    .ForMember(src => src.MovieTypeId, opt => opt.MapFrom(x => x.MovieTypeId))
            //    .ForMember(src => src.DirectorId, opt => opt.MapFrom(x => x.DirectorId));
                //.ForMember(src => src.MovieActors, opt => new List<MovieActor());
                
                



        }
    }
}
