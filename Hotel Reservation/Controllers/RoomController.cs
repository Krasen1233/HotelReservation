using HotelReservation.Models;
using HotelReservation.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new CreateRoomViewModel();
            return this.View(createUserViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateRoomViewModel createRoomViewModel)
        {
            this.roomService.Create(
                createRoomViewModel.Capacity,
                createRoomViewModel.Type,
                createRoomViewModel.PriceOnBed,
                createRoomViewModel.Number,
                createRoomViewModel.Id);

            return RedirectToAction("List");
        }

        [HttpGet]
        public  IActionResult List()
        {
            roomService.GetAll();
            return this.View(roomService);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var room = this.roomService.GetById(id);

            var editRoomViewModel = new RoomViewModel(room.Id, room.Capacity, room.RoomType, room.PriceOnBed, room.Number);
            return this.View(editRoomViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomViewModel roomViewModel)
        {
            this.roomService.Edit(roomViewModel.Id, roomViewModel.Capacity, roomViewModel.Type,
                roomViewModel.PriceOnBed, roomViewModel.Number);
            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            this.roomService.Delete(id);

            return this.RedirectToAction("List");
        }
    }
}
