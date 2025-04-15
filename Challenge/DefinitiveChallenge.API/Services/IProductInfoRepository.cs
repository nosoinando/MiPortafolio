using DefinitiveChallenge.API.Entities;

namespace DefinitiveChallenge.API.Services
{
    public interface IProductInfoRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsAsync(string? searchQuery, string? description);
        Task<Product?> GetProductAsync(int id);
        Task<bool> ProductExistAsync(int id);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Task<bool> SaveChangesAsync();
    }
}
    