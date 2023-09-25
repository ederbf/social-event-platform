using FluentValidation;
using SocialEventPlatform.Application.Activities.Commands.CreateActivity;

namespace SocialEventPlatform.Application.Authentication.Commands.Register
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
