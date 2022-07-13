using CinemasAPI.Entities;
using FluentValidation;
using System.Linq;

namespace CinemasAPI.Models.Validators
{
    public class RegisterUserClientValidator : AbstractValidator<RegisterUserClient>
    {
        public RegisterUserClientValidator(CinemaDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x =>x.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);

                    if(emailInUse)
                    {
                        context.AddFailure("Email", "Adres Email jest już zajęty");
                    }
                });
        }
    }
}
