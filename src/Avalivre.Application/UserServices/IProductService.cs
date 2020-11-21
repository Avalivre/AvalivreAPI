using Avalivre.Domain.Products;
using Avalivre.Infrastructure.DTO.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avalivre.Application.UserServices
{
    public interface IProductService
    {
        Task Delete(int product, long userId);
        Task<Product> Create(CreateProductDTO dto);

        Task<IEnumerable<SimilarProductDTO>> GetSimilarProducts(string name, int fetch = 10);
    }
}
