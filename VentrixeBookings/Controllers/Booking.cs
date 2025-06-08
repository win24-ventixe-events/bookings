using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentrixeBookings.Data.Entities;
using VentrixeBookings.Services;

namespace VentrixeBookings.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Booking(BookingServices service) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBookingAsync([FromBody] UserBookingsEntity entity)
    {
        await service.CreateBookingAsync(entity);
        return Ok(new { message = "Booking saved successfully" });
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync([FromBody] string email)
    {
        var bookings = await service.GetAllAsync(email);
        return Ok(bookings);
    }
}