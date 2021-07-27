using HotelReservation.Data;
using HotelReservation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Service
{
    public class ClientService : IClientService
    {
        private HotelReservationDbContext dbContext;

        public ClientService(HotelReservationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //to do
        public void Create(string firstName, string thirdName, string telephone, string email, int years)
        {
            var newClient = new Client(
                firstName,
                thirdName,
                telephone,
                email,
                years > 18 ? true : false);

            this.dbContext.Add(newClient);
            this.dbContext.SaveChanges();
        }

        public void Delete(int clientId)
        {
            var client = GetById(clientId);
            foreach (var clientReservation in client.ClientsReservations)
            {
                var reservation = this.dbContext.Reservations.Find(clientReservation.ReservationId);
                reservation.ClientsReservations.Remove(clientReservation);
            }

            client.ClientsReservations = new List<ClientReservations>();
            this.dbContext.Clients.Remove(client);
            this.dbContext.SaveChanges();
        }
        //to do
        public void Edit(int id, string firstName, string thirdName, string telephone, string email, bool isAdult)
        {
            var client = GetById(id);

            client.FirstName = firstName;
            client.ThirdName = thirdName;
            client.Telephone = telephone;
            client.Email = email;
            client.IsAdult = isAdult;

            this.dbContext.SaveChanges();
        }
        //to do
        public IEnumerable<Client> GetAll()
        {
            return this.dbContext.Clients.OrderBy(x => x.FirstName).ThenBy(x => x.ThirdName);
        }

        public Client GetById(int id)
        {
            var clients = this.dbContext.Clients.Include(x => x.ClientsReservations).ToList();
            return clients.FirstOrDefault(x => x.Id == id);
        }
    }
}

