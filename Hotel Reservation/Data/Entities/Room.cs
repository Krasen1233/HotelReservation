using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Data.Entities
{
    public class Room
    {
        public Room(int id, int capacity, RoomType roomType, bool isFree, double priceOnBed, int number)
        {
            Id = id;
            Capacity = capacity;
            RoomType = roomType;
            IsFree = isFree;
            PriceOnBed = priceOnBed;
            Number = number;
        }

        public Room()
        {

        }

        public int Id { get; set; }
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; } 
        public bool IsFree { get; set; }
        public double PriceOnBed { get; set; }
        public int Number { get; set; }

    }
}
