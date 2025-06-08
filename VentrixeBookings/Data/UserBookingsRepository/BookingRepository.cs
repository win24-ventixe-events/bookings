using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace VentrixeBookings.Data.Entities.UserBookingsRepository;

public class BookingRepository(DataContext context)
{
    private readonly DbSet<UserBookingsEntity> _dbSet = context.Set<UserBookingsEntity>();
    
    public async Task AddAsync(UserBookingsEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
    }
    
    public virtual async Task<UserBookingsEntity?> GetAsync(Expression<Func<UserBookingsEntity, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }
    
    public virtual async Task<List<UserBookingsEntity>> GetAllAsync(Expression<Func<UserBookingsEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    
    public virtual async Task DeleteAsync(UserBookingsEntity entity)
    {
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        _dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }
    
    public virtual async Task UpdateAsync(UserBookingsEntity entity)
    {
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
    }
}