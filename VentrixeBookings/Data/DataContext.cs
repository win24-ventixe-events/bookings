using Microsoft.EntityFrameworkCore;
using VentrixeBookings.Data.Entities;

namespace VentrixeBookings.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserBookingsEntity> UserBookings { get; set; }
}