using Avalivre.Domain.Products;
using Avalivre.Infrastructure.DTO.Product;
using System.Threading.Tasks;

namespace Avalivre.Application.UserServices
{
    public interface IProductService
    {
        Task<Product> Create(CreateProductDTO dto);
    }
}
