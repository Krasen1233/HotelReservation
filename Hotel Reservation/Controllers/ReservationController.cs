using HotelReservation.Data.Entities;
using HotelReservation.Models;
using HotelReservation.Models.ReservationViewModels;
using HotelReservation.Service;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationService reservationService;
        private IClientService clientService;
        private IRoomService roomService;
        private IHotelUserService hotelUserService;

        public ReservationController(IReservationService reservationService, IClientService clientService,
            IRoomService roomService, IHotelUserService hotelUserService)
        {
            this.reservationService = reservationService;
            this.clientService = clientService;
            this.roomService = roomService;
            this.hotelUserService = hotelUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createReservationViewModel = new CreateReservationViewModel();
            return this.View(createReservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, int peopleCount, DateTime startDate, DateTime endDate,
            RoomType roomType, int roomsId, double price)
        {
            var hotelUser = this.hotelUserService.GetById(id);
            var room = this.roomService.GetById(roomsId);

            this.reservationService.Create(room, hotelUser, peopleCount, startDate, endDate, price, roomType, id);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List(ReservationViewModel reservationViewModel)

        {
            ReservationViewModel reservationView = new ReservationViewModel(reservationViewModel.Id, reservationViewModel.StartDate,
                reservationViewModel.EndDate, reservationViewModel.PeopleCount, reservationViewModel.RoomType, reservationViewModel.RoomNumber, reservationViewModel.Price);
            return this.View(reservationView);
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservation = this.reservationService.GetById(id);
            var people = new List<Client>();

            foreach (var clientReservation in reservation.ClientsReservations)
            {
                var client = this.clientService.GetById(clientReservation.ClientId);

                people.Add(client);
            }

            var detailViewModel = new ReservationDetailsViewModels(reservation.Id, reservation.User,
               reservation.StartDate, reservation.EndDate, people, reservation.Room, reservation.Price);

            return this.View(detailViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var reservation = this.reservationService.GetById(id);
            var editReservation = new EditReservationViewModel(reservation.Id, reservation.StartDate, reservation.EndDate,
                reservation.PeopleCount, reservation.RoomType, reservation.Room, reservation.Price);

            return this.View(editReservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DateTime startDate, DateTime endDate,
            int peopleCount, RoomType roomType, int roomsId, double price)
        {
            var room = this.roomService.GetById(roomsId);

            this.reservationService.Edit(id, startDate, endDate, peopleCount, roomType, room, price);

            return this.RedirectToAction("List");
        }


        public async Task<IActionResult> Delete(int id)
        {
            this.reservationService.Delete(id);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> AddClients(int id)
        {
            var reservation = this.reservationService.GetById(id);

            var addClientsViewModel = new AddClientViewModel(id, reservation.PeopleCount);
            addClientsViewModel.People = this.clientService.GetAll().ToList();

            return this.View(addClientsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddClients(int id, List<int> people)
        {
            var clients = new List<Client>();

            foreach (var peopleId in people)
            {
                var person = this.clientService.GetById(peopleId);
                clients.Add(person);
            }

            this.reservationService.AddClients(clients, id);
            return this.RedirectToAction("List");
        }

        //to add calculate price
        public IActionResult Index()
        {
            return View();
        }
    }
}
