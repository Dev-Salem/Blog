using FluentValidation;

namespace Blog.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidation()
        {
            System.Console.WriteLine("================================================");
            System.Console.WriteLine("RegisterCommandValidation with 4 rules");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).Length(8, 24);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
