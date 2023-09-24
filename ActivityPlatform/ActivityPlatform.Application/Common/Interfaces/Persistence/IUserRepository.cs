using SocialEventPlatform.Domain.User;

namespace SocialEventPlatform.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
