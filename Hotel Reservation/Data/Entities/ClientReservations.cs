using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Data.Entities
{
    public class ClientReservations
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
