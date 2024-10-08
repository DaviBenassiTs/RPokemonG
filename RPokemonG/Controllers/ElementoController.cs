﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RPokemonG.Models;
using RPokemonG.Services;
using RPokemonG.SignalHub;

namespace RPokemonG.Controllers
{
    [Route("api/ElementoController")]
    [ApiController]
    public class ElementoController : Controller
    {
        private readonly ElementoServices _elementoServices;

        public ElementoController(ElementoServices elementoService) 
        {
            _elementoServices = elementoService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Elemento>> GetElemento(string id, [FromServices] IHubContext<ChatHub> hub)
        {
            hub.Clients.All.SendAsync("messageReceived", new {user = "user1", message = "mengao"});
            var elemento = await _elementoServices.GetElemento(id);

            if (elemento is null)
            {
                return NotFound();
            }

            return elemento;
        }

        [HttpGet]
        public async Task<List<Elemento>> GetElemento()
            => await _elementoServices.GetElemento();

        [HttpPost]
        public async Task<Elemento> PostFicha(Elemento elemento)
        {
            await _elementoServices.CreateElemento(elemento);

            return elemento;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Elemento updateElemento)
        {
            var elemento = await _elementoServices.GetElemento(id);

            if (elemento is null)
            {
                return NotFound();
            }

            updateElemento.Id = elemento.Id;

            await _elementoServices.UpdateElemento(id, updateElemento);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var elemento = await _elementoServices.GetElemento(id);

            if (elemento is null)
            {
                return NotFound();
            }

            await _elementoServices.RemoveElemento(id);

            return NoContent();
        }
    }
}
