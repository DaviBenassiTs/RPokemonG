using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPokemonG.Models;
using RPokemonG.Services;

namespace RPokemonG.Controllers
{
    [Route("api/FichaController")]
    [ApiController]
    public class FichaController : Controller
    {
        private readonly FichaServices _fichaServices;

        public FichaController(FichaServices fichaService) 
        {
            _fichaServices = fichaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ficha>> GetFicha(string id)
        {
            var ficha = await _fichaServices.GetFicha(id);

            if (ficha is null)
            {
                return NotFound();
            }

            return ficha;
        }
        [HttpGet]
        public async Task<List<Ficha>> GetFichas()
            => await _fichaServices.GetFicha();

        [HttpPost]
        public async Task<Ficha> PostFicha(Ficha ficha)
        {
            await _fichaServices.CreateFicha(ficha);

            return ficha;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Ficha updateFicha)
        {
            var ficha = await _fichaServices.GetFicha(id);

            if (ficha is null)
            {
                return NotFound();
            }

            updateFicha.Id = ficha.Id;

            await _fichaServices.UpdateFicha(id, updateFicha);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _fichaServices.GetFicha(id);

            if (book is null)
            {
                return NotFound();
            }

            await _fichaServices.RemoveFicha(id);

            return NoContent();
        }
    }
}
