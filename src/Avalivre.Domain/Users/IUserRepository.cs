using System;
using System.Threading.Tasks;

namespace Avalivre.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        void Insert(User entity);
    }
}
