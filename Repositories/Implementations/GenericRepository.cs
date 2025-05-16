using Credit_Management_System.Data;
using Credit_Management_System.Entities;
using Credit_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Management_System.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new ()
    {
        protected readonly AppDBContext _context;
        protected readonly DbSet<T> _entity;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
            => await _entity.AddAsync(entity);

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            _entity.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _entity.Where(e => e.IsDeleted == false).ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
            => await _entity.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);

        public void Update(T entity)
            => _entity.Update(entity);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
