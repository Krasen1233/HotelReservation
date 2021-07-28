using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class AddClientViewModel
    {
        public AddClientViewModel(int reservationId, int peopleCount)
        {
            ReservationId = reservationId;
            PeopleCount = peopleCount;
        }

        public AddClientViewModel()
        {

        }

        public int ReservationId { get; set; }

        public int PeopleCount { get; set; }

        public IEnumerable<Client> People { get; set; }
    }
}
