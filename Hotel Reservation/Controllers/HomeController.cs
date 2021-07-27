using HotelReservation.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        private IHotelUserService hotelUserService;
        private IReservationService reservationService;

        public HomeController(IHotelUserService hotelUserService, IReservationService reservationService)
        {
            this.hotelUserService = hotelUserService;
            this.reservationService = reservationService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
