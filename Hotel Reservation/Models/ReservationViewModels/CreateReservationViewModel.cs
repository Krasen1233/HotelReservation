using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class CreateReservationViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PeopleCount { get; set; }

        public RoomType Type { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        public double Price { get; set; }
    }
}
