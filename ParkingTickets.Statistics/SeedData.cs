using ParkingTickets.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingTickets.Statistics;
public static class SeedData
{
    public static IEnumerable<Ticket> Seed(int count)
    {
        List<Ticket> list = new List<Ticket>();

        Random random = new Random();
        foreach (int i in Enumerable.Range(0, count))
        {
            var minutes = random.Next(0, 18 * 60);

            var timeOfDay = TimeSpan.FromMinutes(minutes);

            var dt = new DateTime(2024, 05, 20) + timeOfDay;
            Ticket ticket = new Ticket
            {
                TimeOfTicket = dt,
                LocationId = 11,
            };
            list.Add(ticket);
        }

        return list;
    }
}
