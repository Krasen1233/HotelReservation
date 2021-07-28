using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class CreateUserViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string ThirdName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}
