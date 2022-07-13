using CinemasAPI.Entities;
using CinemasAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CinemasAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserClient client);
    }
    public class AccountService : IAccountService
    {
        private readonly CinemaDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountService(CinemaDbContext context, IPasswordHasher<User> passwordHasher)
        { 
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterUserClient client)
        {
            var newUser = new User()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                RoleId = client.RoleId,
            };


            var hashedPassword = _passwordHasher.HashPassword(newUser, client.Password);

            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
