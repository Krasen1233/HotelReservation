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
    public class ReservationService : IReservationService
    {
        private HotelReservationDbContext dbContext;

        public ReservationService(HotelReservationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //to work here
        public void AddClients(List<Client> clients, int reservationId)
        {
            var reservation = GetById(reservationId);

            foreach (var client in clients)
            {
                var clientReservation = new ClientReservations()
                {
                    ClientId = client.Id,
                    Client = client,
                    ReservationId = reservationId,
                    Reservation = reservation
                };

                client.ClientsReservations.Add(clientReservation);
                reservation.ClientsReservations.Add(clientReservation);
            }

            this.dbContext.SaveChanges();
        }

        public double CalculatePrice(int peopleCount, Room room, DateTime startDate, DateTime endDate)
        {
            var time = (endDate - startDate).TotalDays;
            return (peopleCount * room.PriceOnBed) * time;
        }
        //to add hoteluser and to work on id
        public void Create(Room room, HotelUser hotelUser, int peopleCount, DateTime startDate, DateTime endDate,
            double price, RoomType roomType, int id)
        {
            room.IsFree = false;

            var reservation = new Reservation()
            {
                Id = id,
                Room = room,
                RoomType = roomType,
                User=hotelUser,
                PeopleCount = peopleCount,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            };

            this.dbContext.Add(reservation);
            this.dbContext.SaveChanges();
        }

        public void Delete(int reservationId)
        {
            var reservation = GetById(reservationId);
            RemoveClient(reservation);
            this.dbContext.Reservations.Remove(reservation);
            this.dbContext.SaveChanges();

        }

        public void Edit(int id, DateTime startDate, DateTime endDate, int peopleCount, RoomType roomType, Room room, double price)
        {
            var reservation = GetById(id);

            reservation.Room = room;
            reservation.StartDate = startDate;
            reservation.EndDate = endDate;
            if (reservation.PeopleCount != peopleCount)
            {
                reservation.PeopleCount = peopleCount;
            }
            reservation.RoomType = roomType;

            this.dbContext.SaveChanges();

        }

        public IEnumerable<Reservation> GetAll()
        {
            return this.dbContext.Reservations.Include(x => x.Room).Include(x => x.User).Include(x => x.ClientsReservations)
                .Include(x => x.StartDate).Include(x => x.EndDate);
        }

        public Reservation GetById(int id)
        {
            var reservations = this.dbContext.Reservations.Include(x => x.User).Include(x => x.Room).Include(x => x.ClientsReservations).ToList();
            return reservations.FirstOrDefault(x => x.Id == id);
        }

        private void RemoveClient(Reservation reservation)
        {
            foreach (var clientReservation in reservation.ClientsReservations)
            {
                var client = this.dbContext.Clients.Find(clientReservation.ClientId);
                client.ClientsReservations.Remove(clientReservation);
            }
            reservation.ClientsReservations = new List<ClientReservations>();
        }
    }
}
