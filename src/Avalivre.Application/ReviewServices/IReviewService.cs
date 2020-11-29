using Avalivre.Infrastructure.DTO.Review;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avalivre.Application.ReviewServices
{
    public interface IReviewService
    {
        Task<ReviewDTO> Create(CreateReviewDTO dto);
        Task<ICollection<ReviewDTO>> GetRecentByproduct(GetRecentReviewsDTO dto);
        Task<ReviewDTO> Get(long id);
    }
}
