using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models.UserViewModel
{
    public class ActiveUserViewModel
    {
        public ActiveUserViewModel(int id, string username, string firstName, string thirdName, 
            string telephone, string email, DateTime startDate)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            ThirdName = thirdName;
            Telephone = telephone;
            Email = email;
            StartDate = startDate;
        }
        public ActiveUserViewModel()
        {

        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string ThirdName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public DateTime StartDate { get; set; }
    }
}
