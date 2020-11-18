using Avalivre.Domain.Products;
using Avalivre.Infrastructure.Persistence.Abstracts;

namespace Avalivre.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Context.DataContext context) : base(context)
        {
        }
    }
}
