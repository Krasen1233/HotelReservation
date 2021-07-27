using HotelReservation.Data;
using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Service
{
    public class HotelUserService : IHotelUserService
    {
        private HotelReservationDbContext dbContext;

        public HotelUserService(HotelReservationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // to do
        public void Activate(int hotelUserId)
        {
            var currUser = GetById(hotelUserId);
            currUser.IsActive = true;
            currUser.StartDate = DateTime.Now;
            currUser.EndDate = default(DateTime);

            dbContext.SaveChanges();
        }

        public bool AreThereAnyUsers()
        {
            return this.dbContext.Users.Count() > 0;
        }

        public void Block(int hotelUserId)
        {
            var currUser = GetById(hotelUserId);
            currUser.IsActive = false;
            currUser.EndDate = DateTime.UtcNow;

            dbContext.SaveChanges();
        }

        public void Edit(int id, string username, string firstName, string thirdName,
            string telephone, string email, DateTime startDate, DateTime endDate)
        {
            var hotelUser = GetById(id);

            hotelUser.UserName = username;
            hotelUser.FirstName = firstName;
            hotelUser.ThirdName= thirdName;
            hotelUser.Telephone = telephone;
            hotelUser.Email = email;
            hotelUser.StartDate = startDate;
            hotelUser.EndDate = endDate;

            dbContext.SaveChanges();
        }

        public IEnumerable<HotelUser> GetAllActive()
        {
            var active = this.dbContext.Users.Where(x => x.IsActive == true)
                .OrderBy(x => x.UserName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.ThirdName)
                .ToList();

            return active;
        }

        public IEnumerable<HotelUser> GetAllBlocked()
        {
            var blocked = this.dbContext.Users.Where(x => x.IsActive == false)
                .OrderBy(x => x.UserName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.ThirdName)
                .ToList();

            return blocked;
        }

        public HotelUser GetById(int id)
        {
            return this.dbContext.Users.Find(id);
        }

        public HotelUser GetCurrent(string  concurrencyStamp)
        {
            var hotelUser = this.dbContext.Users.FirstOrDefault(x => x.ConcurrencyStamp == concurrencyStamp);
            return hotelUser;
        }
    }
}
