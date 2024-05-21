using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingTickets.Database.Entities;

public partial class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    [MaxLength(100)]
    public string? Description { get; set; } = null!;
    [ForeignKey(nameof(ParentLocation))]
    public int? LocationCategoryId { get; set; }
    public virtual Location ParentLocation { get; set; }

    public DateTime? RecordInactive { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<Location> ChildTickets { get; set; } = new List<Location>();
}
