using System.Diagnostics;
using VentrixeBookings.Data.Entities;
using VentrixeBookings.Data.Entities.UserBookingsRepository;

namespace VentrixeBookings.Services;

public class BookingServices(BookingRepository repository)
{
    public async Task CreateBookingAsync(UserBookingsEntity entity)
    {
        try
        {
            await repository.AddAsync(entity);
            
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
           
            throw;
        }
    }
    
    public async Task<List<UserBookingsEntity>> GetAllAsync(string email)
    {
        try
        {
            return await repository.GetAllAsync(booking => booking.UserEmail == email);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }
    
    public async Task<UserBookingsEntity> GetByIdAsync(int id)
    {
        try
        {
            var eventEntity = await repository.GetAsync(x => x.Id == id);
            if (eventEntity == null)
            {
                throw new Exception("Project not found");
            }
            return eventEntity;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }
    
    public async Task DeleteAsync(int id)
    {
        try
        {
            var entityToDelete = await GetByIdAsync(id);
            if (entityToDelete == null)
            {
                throw new Exception("Booking Not found");
            }
            
            await repository.DeleteAsync(entityToDelete);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }
    
    
    public async Task UpdateAsync(UserBookingsEntity entity)
    {
        try
        {
            await repository.UpdateAsync(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}