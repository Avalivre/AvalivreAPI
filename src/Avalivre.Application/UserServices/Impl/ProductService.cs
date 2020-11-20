using Avalivre.Domain.Products;
using Avalivre.Infrastructure.DTO.Product;
using Avalivre.Infrastructure.Persistence.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avalivre.Application.UserServices.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly UnitOfWork _uow;

        public ProductService(
            UnitOfWork uow,
            IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._uow = uow;
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

        public Task<IEnumerable<SimilarProductDTO>> GetSimilarProducts(string name, int fetch = 10)
        {
            return _productRepository.GetSimilarProducts(name.ToLower(), fetch);
        }
    }
}
