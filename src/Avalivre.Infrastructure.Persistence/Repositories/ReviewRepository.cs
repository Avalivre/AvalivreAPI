using Avalivre.Domain.Reviews;
using Avalivre.Infrastructure.DTO.Review;
using Avalivre.Infrastructure.Persistence.Abstracts;
using Avalivre.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avalivre.Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(Context.DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<ReviewDTO>> GetRecentByProduct(long productId, int fetch)
        {
            return await _context.Reviews
                .Where(r => r.ProductId == productId)
                .Include(r => r.Product)
                .OrderByDescending(r => r.CreationDate)
                .Select(r => new ReviewDTO
                {
                    Description = r.Description,
                    ProductName = r.Product.Name,
                    Rating = r.Rating
                })
                .Take(fetch)
                .ToListAsync();
        }
    }
}
