using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Service
{
    public interface IRoomService
    {
        void Create(int capacity, RoomType type, double priceOnBed, int number, int id);

        void Delete(int roomId);

        void Edit(int id, int capacity, RoomType type, double priceOnBed, int number);

        IEnumerable<Room> GetAll();

        Room GetById(int id);
    }
}
