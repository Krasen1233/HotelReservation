using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class ReservationViewModel
    {
        public ReservationViewModel(int id,  DateTime startDate, DateTime endDate,
            int peopleCount, RoomType roomType, int roomNumber, double price)
        {
            Id = id;
           // Username = username;
            StartDate = startDate;
            EndDate = endDate;
            PeopleCount = peopleCount;
            RoomType = roomType;
            RoomNumber = roomNumber;
            Price = price;
           // ClientReservationCount = clientReservationCount;
        }

        public ReservationViewModel()
        {

        }

        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PeopleCount { get; set; }

        public RoomType RoomType { get; set; }

        public int RoomNumber { get; set; }

        public double Price { get; set; }

        public int ClientReservationCount { get; set; }
    }
}
