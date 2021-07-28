using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models.ReservationViewModels
{
    public class ReservationDetailsViewModels
    {
        public ReservationDetailsViewModels(int id, HotelUser hotelUser,
            DateTime startDate, DateTime endDate, List<Client> people, Room room, double price)
        {
            Id = id;
            HotelUser = hotelUser;
            StartDate = startDate;
            EndDate = endDate;
            People = people;
            Room = room;
            Price = price;
        }

        public ReservationDetailsViewModels()
        {
                
        }
        public int Id { get; set; }

        public HotelUser HotelUser { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public List<Client> People { get; set; }

        public Room Room { get; set; }

        public double Price { get; set; }
    }
}
