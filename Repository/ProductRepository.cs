using MicroservicesWithCQRSDesignPattern.AppDbContext;
using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesWithCQRSDesignPattern.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Product>().FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Set<Product>().ToListAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _dbContext.Set<Product>().AddAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            _dbContext.Set<Product>().Update(entity);
        }

        public async Task DeleteAsync(Product entity)
        {
            _dbContext.Set<Product>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
