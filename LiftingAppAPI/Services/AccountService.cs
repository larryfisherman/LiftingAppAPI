using LiftingAppAPI.Entities;
using LiftingAppAPI.Exceptions;
using LiftingAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LiftingAppAPI.Services
{

    public interface IAccountService
    {
        public string GenerateJwt(LoginDto dto);
        public void RegisterUser(RegisterUserDto dto);
        public IEnumerable<User> GetAll();

    }

    public class AccountService : IAccountService
    {
        private readonly LiftingAppDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(LiftingAppDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _dbContext.Users
                .Include(w => w.Workouts)
                .ToList();
            return users;
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email);

            if (user is null) throw new BadRequestException("Invalid username or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               //new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
               new Claim(ClaimTypes.Name, $"{user.Id}"),
               new Claim(type: JwtRegisteredClaimNames.Sub, value: user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges(); 
        }
    }
}
