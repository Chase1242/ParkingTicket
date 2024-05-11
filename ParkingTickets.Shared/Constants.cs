namespace ParkingTickets.Shared;

public class Constants
{
    /// <summary>
    /// The number of bins in a day. Represents all 24 hours, split into 5 minute chunks.
    /// </summary>
    public int Bins { get => (24 * 60) / 5; }
}
