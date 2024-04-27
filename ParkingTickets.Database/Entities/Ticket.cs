using System;
using System.Collections.Generic;

namespace ParkingTickets.Database.Entities;

public partial class Ticket
{
    public int TicketId { get; set; }

    public DateTime TimeOfTicket { get; set; }

    public int LocationId { get; set; }

    public string? TicketNumber { get; set; }

    public string? TicketingOfficerName { get; set; }

    public string? ViolationType { get; set; }

    public virtual Location Location { get; set; } = null!;
}
