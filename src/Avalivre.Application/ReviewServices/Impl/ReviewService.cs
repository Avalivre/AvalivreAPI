using Avalivre.Domain.Products;
using Avalivre.Domain.Reviews;
using Avalivre.Domain.Users;
using Avalivre.Infrastructure.DTO.Review;
using Avalivre.Infrastructure.Persistence.UnitOfWork;
using System;
using System.Threading.Tasks;
using Yaba.Tools.Validations;

namespace Avalivre.Application.ReviewServices.Impl
{
    public class ReviewService : IReviewService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly UnitOfWork _uow;

        public ReviewService(
            IProductRepository productRepository,
            IReviewRepository reviewRepository,
            IUserRepository userRepository,
            UnitOfWork uow)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _uow = uow;
        }

        public async Task<ReviewDTO> Create(CreateReviewDTO dto)
        {
            var user = await _userRepository.GetById(dto.UserId);
            Validate.NotNull(user, "É preciso estar logado para fazer uma avaliação");

            var product = await _productRepository.GetById(dto.ProductId);
            Validate.NotNull(product, "Produto não encontrado");

            var review = new Review(dto.Description, dto.Rating, product.Id, user.Id);

            _reviewRepository.Insert(review);

            Validate.IsTrue(await _uow.CommitAsync(), "Não foi possível criar a avaliação");

            return new ReviewDTO
            {
                Description = review.Description,
                ProductName = product.Name,
                Rating = review.Rating
            };
        }
    }
}
