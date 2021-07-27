using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Data.Entities
{
    public class Client
    {
        public Client(string firstName, string thirdName, string telephone, string email, bool isAdult)
        {
            FirstName = firstName;
            ThirdName = thirdName;
            Telephone = telephone;
            Email = email;
            IsAdult = isAdult;
        }
        public Client()
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string ThirdName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }
        public ICollection<ClientReservations> ClientsReservations { get; set; }
    }
}
