using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class CreateRoomViewModel
    {
        public int Id { get; set; }
       
        public int Capacity { get; set; }

        public RoomType Type { get; set; }

        public double  PriceOnBed { get; set; }

        public int Number { get; set; }
    }
}
