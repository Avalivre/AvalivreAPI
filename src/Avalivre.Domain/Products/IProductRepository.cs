using Avalivre.Infrastructure.DTO.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avalivre.Domain.Products
{
    public interface IProductRepository
    {
        void Insert(Product product);
        Task<IEnumerable<SimilarProductDTO>> GetSimilarProducts(string name, int fetch);
    }
}
