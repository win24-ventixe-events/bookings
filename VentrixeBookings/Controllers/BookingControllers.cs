using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentrixeBookings.Data.Entities;
using VentrixeBookings.Services;

namespace VentrixeBookings.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BookingControllers(BookingServices service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBookingAsync([FromBody] UserBookingsEntity entity)
    {
        await service.CreateBookingAsync(entity);
        return Ok(new { message = "Booking saved successfully" });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var bookings = await service.GetAllAsync();
        return Ok(bookings);
    }
}