using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Service
{
    public interface IReservationService
    {
        void Create(Room room, HotelUser hotelUser, int peopleCount, DateTime startDate, DateTime endDate, double price, RoomType roomType,int id);

        double CalculatePrice(int peopleCount, Room room, DateTime startDate, DateTime endDate);
        //to do
        void Edit(int id, DateTime startDate, DateTime endDate, int peopleCount, RoomType roomType, Room room, double price);

        void Delete(int reservationId);

        void AddClients(List<Client> clients, int reservationId);

        IEnumerable<Reservation> GetAll();

        Reservation GetById(int id);
    }
}
