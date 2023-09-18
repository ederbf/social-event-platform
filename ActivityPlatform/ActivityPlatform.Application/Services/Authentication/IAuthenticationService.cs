namespace ActivityPlatform.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string firstName, string lastName, string email, string password);
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }
}