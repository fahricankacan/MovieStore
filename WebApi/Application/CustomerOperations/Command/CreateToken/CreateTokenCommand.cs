using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.CustomerOperations.Command.CreateToken
{
    public class CreateTokenCommand
    {

        public CreateTokenViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Customers.FirstOrDefault(p => p.Email == Model.Email && p.Password == Model.Password);

            if (user is not null)
            {
                WebApi.TokenOperations.TokenHandler handler = new TokenOperations.TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;

            }
            else
            {
                throw new InvalidOperationException("Kullanıcı Adı veya Şifre Hatalı!");
            }

        }

    }

    public class CreateTokenViewModel
    {

        public string Email { get; set; }
        public string Password { get; set; }

    }
}
