using System.Threading.Tasks;

namespace Avalivre.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(object id);
        void Insert(User entity);
    }
}
