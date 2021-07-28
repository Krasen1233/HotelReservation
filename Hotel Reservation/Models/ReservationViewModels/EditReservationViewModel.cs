using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class EditReservationViewModel
    {
        public EditReservationViewModel(int id, DateTime startDate, DateTime endDate,
            int peopleCount, RoomType roomType, Room room, double price)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            PeopleCount = peopleCount;
            RoomType = roomType;
            Price = price;
            Room = room;
        }

        public EditReservationViewModel(int id)
        {

        }

        public EditReservationViewModel()
        {

        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PeopleCount { get; set; }

        public RoomType RoomType { get; set; }

      //  public IEnumerable<Room> Rooms { get; set; }

        public Room Room { get; set; }

        public double Price { get; set; }
    }
}
