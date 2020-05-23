using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using supplierapi;
using supplierapi.Helpers;

namespace supplierapi.Services
{
    public interface IStoreUserService
    {
        StoreUser Authenticate(string username, string password);
        IEnumerable<StoreUser> GetAll();
    }

    public class StoreUserService : IStoreUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<StoreUser> _users = new List<StoreUser>
        { 
            new StoreUser { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" } 
        };

        private readonly AppSettings _appSettings;

        public StoreUserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public StoreUser Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public IEnumerable<StoreUser> GetAll()
        {
            return _users;
        }
    }
}