using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public HotelUser User { get; set; }
        public int PeopleCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoomType RoomType { get; set; } 
        public double Price { get; set; }
        public ICollection<ClientReservations> ClientsReservations { get; set; }
    }
}
