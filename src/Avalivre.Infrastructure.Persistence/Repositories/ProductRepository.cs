using Avalivre.Domain.Products;
using Avalivre.Infrastructure.DTO.Product;
using Avalivre.Infrastructure.Persistence.Abstracts;
using Avalivre.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avalivre.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(Context.DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SimilarProductDTO>> GetSimilarProducts(string name, int fetch)
        {
            return await this._context.Products
                .Where(p => p.Name.Contains(name))
                .Select(p => new SimilarProductDTO { Id = p.Id, Name = p.Name, ModelCode = p.ModelCode })
                .Take(fetch)
                .ToListAsync();
        }

        public override void Update(Product entity)
        {
            entity.SetUpdateDate();
            base.Update(entity);
        }
    }
}
