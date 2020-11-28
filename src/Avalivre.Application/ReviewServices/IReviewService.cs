using Avalivre.Infrastructure.DTO.Review;
using System.Threading.Tasks;

namespace Avalivre.Application.ReviewServices
{
    public interface IReviewService
    {
        Task<ReviewDTO> Create(CreateReviewDTO dto);
    }
}
