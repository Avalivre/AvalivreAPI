using Avalivre.Domain.Users;
using Avalivre.Infrastructure.Persistence.Abstracts;

namespace Avalivre.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context.DataContext context) : base(context)
        {
        }
    }
}
