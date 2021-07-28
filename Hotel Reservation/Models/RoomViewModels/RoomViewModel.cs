using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class RoomViewModel
    {
        public RoomViewModel(int id, int capacity, RoomType type, double priceOnBed, int number)
        {
            Id = id;
            Capacity = capacity;
            Type = type;
            PriceOnBed = priceOnBed;
            Number = number;
        }

        public RoomViewModel()
        {
        }

        public int Id { get; set; }

        public int Capacity { get; set; }

        public RoomType Type { get; set; }

        public double PriceOnBed { get; set; }

        public int Number { get; set; }

        public bool IsFree { get; set; }
    }
}
