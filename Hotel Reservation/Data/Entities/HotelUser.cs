using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Data.Entities
{
    public class HotelUser : IdentityUser<int>
    {
        public HotelUser()
        {

        }
        public string FirstName { get; set; }

        public string ThirdName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
        public string Telephone { get;  set; }
    }
}
