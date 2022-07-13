using CinemasAPI.Entities;
using CinemasAPI.Models;

namespace CinemasAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserClient client);
    }
    public class AccountService : IAccountService
    {
        private readonly CinemaDbContext _context;
        public AccountService(CinemaDbContext context)
        { 
            _context = context;
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

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
