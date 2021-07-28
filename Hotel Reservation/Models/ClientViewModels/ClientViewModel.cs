using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class ClientViewModel
    {
        public ClientViewModel( string firstName, string thirdName, string telephone, string email)
        {

            FirstName = firstName;
            ThirdName = thirdName;
            Telephone = telephone;
            Email = email;
        }

        public ClientViewModel()
        {

        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string ThirdName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }
    }
}
