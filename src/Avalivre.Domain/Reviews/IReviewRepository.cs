using Avalivre.Infrastructure.DTO.Review;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avalivre.Domain.Reviews
{
    public interface IReviewRepository
    {
        void Insert(Review entity);
        Task<ICollection<ReviewDTO>> GetRecentByProduct(long productId, int fetch);
    }
}
