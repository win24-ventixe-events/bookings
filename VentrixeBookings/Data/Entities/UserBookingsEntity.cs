using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentrixeBookings.Data.Entities;

public class UserBookingsEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(25)]
    public string EventName { get; set; } = null!;

    [Required] public int EventId { get; set; }
    
    [Required] public string UserEmail { get; set; } = null!;
    
    [Required] public string UserId { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateTime DateBooked { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }
    
    [Required] public string Location { get; set; } = null!;
    

    [Required] public int NumberOfTickets { get; set; }
}