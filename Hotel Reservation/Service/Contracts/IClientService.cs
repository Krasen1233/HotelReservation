using HotelReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IClientService
    {
        void Create(string firstName, string lastName, string telephone, string email, int years );

        void Delete(int clientId);

        void Edit(int id, string firstName, string thirdName, string telephone, string email, bool isAdult);

        IEnumerable<Client> GetAll();

        Client GetById(int id);
    }
}
