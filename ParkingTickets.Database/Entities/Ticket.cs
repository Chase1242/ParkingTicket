using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingTickets.Database.Entities;

public partial class Ticket
{
    [Key]
    public int TicketId { get; set; }

    public DateTime TimeOfTicket { get; set; }

    public int LocationId { get; set; }

    public string? TicketNumber { get; set; }

    public string? TicketingOfficerName { get; set; }

    public string? ViolationType { get; set; }

    public virtual Location Location { get; set; } = null!;
}
