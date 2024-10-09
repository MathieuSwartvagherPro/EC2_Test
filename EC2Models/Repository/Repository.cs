using EC2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EC2Models.Repository
{
    public abstract class Repository<T> where T : class
    {
        protected readonly EC2Context _context;

        protected Repository(EC2Context context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        private void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            Update(entity);
            await SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
