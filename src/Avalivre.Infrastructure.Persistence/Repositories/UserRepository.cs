using Avalivre.Domain.Users;
using Avalivre.Infrastructure.Persistence.Abstracts;
using Avalivre.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Avalivre.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(Context.DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
