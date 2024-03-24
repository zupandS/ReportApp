using Microsoft.EntityFrameworkCore;
using Report.Core.Entities;
using Report.Core.Interfaces.Repositories;

namespace Report.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _dataContext.Users.Add(user);

            await _dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            var user = await _dataContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _dataContext.Update(user);

            await _dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserByTokenAsync(string refreshToken)
        {
            var user = await _dataContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            return user;
        }
    }
}