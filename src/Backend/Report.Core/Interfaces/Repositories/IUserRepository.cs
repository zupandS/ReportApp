using Report.Core.Entities;

namespace Report.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);

        Task<User> GetUserByLoginAsync(string login);

        Task<User> UpdateAsync(User user);
    }
}