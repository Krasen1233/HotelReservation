using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Service
{
    public interface IHotelUserService
    {
        bool AreThereAnyUsers();

        void Activate(int hotelUserId);

        void Block(int hotelUserId);
        // to do
        void Edit(int id, string username, string firstName, string thirdName,
            string telephone, string email, DateTime startDate, DateTime endDate);

        HotelUser GetCurrent(string concurrencyStamp);

        public IEnumerable<HotelUser> GetAllActive();

        public IEnumerable<HotelUser> GetAllBlocked();

        HotelUser GetById(int id);
    }
}
