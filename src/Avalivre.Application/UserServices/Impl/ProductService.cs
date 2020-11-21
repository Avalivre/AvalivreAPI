using Avalivre.Domain.Products;
using Avalivre.Domain.Users;
using Avalivre.Infrastructure.DTO.Product;
using Avalivre.Infrastructure.Persistence.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yaba.Tools.Validations;

namespace Avalivre.Application.UserServices.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly UnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public ProductService(
            UnitOfWork uow,
            IUserRepository userRepository,
            IProductRepository productRepository)
        {
            this._uow = uow;
            this._userRepository = userRepository;
            this._productRepository = productRepository;
        }

        public async Task<Product> Create(CreateProductDTO dto)
        {
            var product = new Product(dto.Name, dto.Brand);

            if (!string.IsNullOrEmpty(dto.ModelCode))
                product.SetModelCode(dto.ModelCode);

            if (!string.IsNullOrEmpty(dto.Material))
                product.SetMaterial(dto.Material);

            _productRepository.Insert(product);
            await _uow.CommitAsync();

            return product;
        }

        public async Task Delete(int productId, long userId)
        {
            var user = await _userRepository.GetById(userId);

            Validate.IsTrue(user.IsAdmin, "Somente administradores possuem acesso a este recurso.");

            var product = await _productRepository.GetById(productId);

            Validate.NotNull(product, "O produto não foi encontrado");

            _productRepository.Delete(product);

            await _uow.CommitAsync();
        }

        public Task<IEnumerable<SimilarProductDTO>> GetSimilarProducts(string name, int fetch = 10)
        {
            if (string.IsNullOrEmpty(name) || name.Length <= 2)
                return Task.FromResult(default(IEnumerable<SimilarProductDTO>));

            return _productRepository.GetSimilarProducts(name.ToLower(), fetch);
        }
    }
}
