using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    public class ClientController : Controller
    {

        private IClientService clientService;
        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new CreateClientViewModel();
            return this.View(createUserViewModel);
        }

        [HttpPost]
        //to do
        public async Task<IActionResult> Create(CreateClientViewModel createClientViewModel)
        {
            this.clientService.Create(
                createClientViewModel.FirstName,
                createClientViewModel.ThirdName,
                createClientViewModel.Telephone,
                createClientViewModel.Email,
                createClientViewModel.Years
                );

            return this.RedirectToAction("List", createClientViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List(CreateClientViewModel createClientViewModel)
        {
            ClientViewModel clientViewModel = new ClientViewModel(createClientViewModel.FirstName, createClientViewModel.ThirdName,
                createClientViewModel.ThirdName,createClientViewModel.Email);
            return this.View(clientViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = this.clientService.GetById(id);

            var editClientViewModel = new ClientViewModel(client.FirstName, client.ThirdName,
                client.Telephone, client.Email);

            return this.View(editClientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel clientViewModel)
        {
            this.clientService.Edit(clientViewModel.Id, clientViewModel.FirstName, clientViewModel.ThirdName,
                clientViewModel.Telephone, clientViewModel.Email, clientViewModel.IsAdult);

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            this.clientService.Delete(id);

            return this.RedirectToAction("List");
        }
    }
}
