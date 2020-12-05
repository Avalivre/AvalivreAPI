using Avalivre.Infrastructure.DTO.Review;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avalivre.Domain.Reviews
{
    public interface IReviewRepository
    {
        void Insert(Review entity);
        void Delete(Review entity);
        Task<Review> GetById(object id);
        Task<ICollection<ReviewDTO>> GetRecentByProduct(long productId, int fetch);
        Task<ReviewDTO> GetWithProduct(long id);
    }
}
