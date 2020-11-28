using Avalivre.Domain.Reviews;
using Avalivre.Infrastructure.Persistence.Abstracts;
using Avalivre.Infrastructure.Persistence.Context;

namespace Avalivre.Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(Context.DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
