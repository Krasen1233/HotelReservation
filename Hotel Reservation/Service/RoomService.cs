using HotelReservation.Data;
using HotelReservation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Service
{
    public class RoomService : IRoomService
    {
        private HotelReservationDbContext dbContext;

        public RoomService(HotelReservationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(int capacity, RoomType type, double priceOnBed, int number, int id)
        {
            var newRoom = new Room(
                id,
                capacity,
                type,
                true,
                priceOnBed,
                number);

            this.dbContext.Rooms.Add(newRoom);
            this.dbContext.SaveChanges();
        }

        public void Delete(int roomId)
        {
            var room = GetById(roomId);

            foreach(var reservation in this.dbContext.Reservations.Include(x => x.Room).Include(x => x.ClientsReservations))
            {
                if (reservation.Room == room)
                {
                    foreach(var clientReservation in reservation.ClientsReservations)
                    {
                        var client = this.dbContext.Clients.Find(clientReservation.ClientId);
                        client.ClientsReservations = new List<ClientReservations>();
                    }
                    this.dbContext.Reservations.Remove(reservation);
                }
            }

            this.dbContext.Rooms.Remove(room);
            this.dbContext.SaveChanges();
        }

        public void Edit(int id, int capacity, RoomType type, double priceOnBed, int number)
        {
            var room = GetById(id);

            room.Id = id;
            room.Capacity = capacity;
            room.RoomType = type;
            room.PriceOnBed = priceOnBed;
            room.Number = number;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return this.dbContext.Rooms.OrderBy(x => x.Number).ThenBy(x => x.RoomType).ThenBy(x => x.Capacity).ToList();
        }

        public Room GetById(int id)
        {
            return this.dbContext.Rooms.Find(id);
        }
    }
}
