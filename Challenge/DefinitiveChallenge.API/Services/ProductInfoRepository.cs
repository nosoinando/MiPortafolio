using DefinitiveChallenge.API.DbContexts;
using DefinitiveChallenge.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefinitiveChallenge.API.Services
{
    public class ProductInfoRepository : IProductInfoRepository
    {
        private readonly ProductInfoContext _context;

        public ProductInfoRepository(ProductInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string? description, string? searchQuery)
        {
            if (string.IsNullOrEmpty(description)
                && string.IsNullOrWhiteSpace(searchQuery))
            {
                return await GetProductsAsync();
            }

            //Collection to start from
            var collection = _context.Products as IQueryable<Product>;

            if(!string.IsNullOrWhiteSpace(description))
            {
                description = description.Trim();
                collection = collection.Where(p => p.Description == description);
            }

            if(!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Description.Contains(searchQuery) 
                || (a.Description != null && a.Description.Contains(searchQuery)));
            }

            return await collection.OrderBy(p => p.Description).ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _context.Products
                .Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> ProductExistAsync(int id)
        {
            return await _context.Products.AnyAsync(c => c.Id == id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }   
    }
}
