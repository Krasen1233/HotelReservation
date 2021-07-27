using HotelReservation.Data.Entities;
using HotelReservation.Models.UserViewModel;
using HotelReservation.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    public class HotelUserController : Controller
    {
        private IHotelUserService hotelUserService;
        private UserManager<HotelUser> userManager;

        public HotelUserController(IHotelUserService hotelUserService, UserManager<HotelUser> userManager)
        {
            this.hotelUserService = hotelUserService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ActiveList()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> BlockedList()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> EditActiveUser(int id)
        {
            var activeUser = this.hotelUserService.GetById(id);

            var editActiveUser = new ActiveUserViewModel(activeUser.Id, activeUser.UserName,
                activeUser.FirstName, activeUser.ThirdName, activeUser.Telephone, activeUser.Email, activeUser.StartDate);

            return this.View(editActiveUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditActiveUser(ActiveUserViewModel activeUserViewModel)
        {
            this.hotelUserService.Edit(activeUserViewModel.Id, activeUserViewModel.Username,
                activeUserViewModel.FirstName, activeUserViewModel.ThirdName, activeUserViewModel.Telephone,
                activeUserViewModel.Email, activeUserViewModel.StartDate, default(DateTime));

            return this.RedirectToAction("ActiveList", "HotelUser");
        }

        [HttpGet]
        public async Task<IActionResult> EditBlockedUser(int id)
        {
            var blockedUser=this.hotelUserService.GetById(id);
            var editBlockedUser = new BlockedUserViewModel(blockedUser.Id, blockedUser.UserName,
                blockedUser.FirstName, blockedUser.ThirdName, blockedUser.Telephone, blockedUser.Email,
                blockedUser.StartDate, blockedUser.EndDate);

            return this.View(editBlockedUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlockedUser(BlockedUserViewModel blockedUserViewModel)
        {
            this.hotelUserService.Edit(blockedUserViewModel.Id, blockedUserViewModel.Username,
                blockedUserViewModel.FirstName, blockedUserViewModel.ThirdName, blockedUserViewModel.Telephone,
                blockedUserViewModel.Email, blockedUserViewModel.StartDate, blockedUserViewModel.EndDate);

            return this.RedirectToAction("BlockedList", "HotelUser");
        }

        public async Task<IActionResult> Block(int id)
        {
            this.hotelUserService.Block(id);
            return this.RedirectToAction("BlockedList", "HotelUser");
        }

        public async Task<IActionResult> Activate(int id)
        {
            this.hotelUserService.Activate(id);
            return this.RedirectToAction("ActiveList", "HotelUser");
        }

    }
}
