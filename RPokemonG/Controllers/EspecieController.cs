using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPokemonG.Models;
using RPokemonG.Services;
using System.Net.Mime;

namespace RPokemonG.Controllers
{
    [Route("api/EspecieController")]
    [ApiController]
    public class EspecieController : Controller
    {
        private readonly EspecieServices _especieServices;

        public EspecieController(EspecieServices especieService) 
        {
            _especieServices = especieService;
        }
        [HttpGet]
        public async Task<List<Especie>> GetEspecie()
    => await _especieServices.GetEspecie();

        [HttpGet("{id}")]
        [ProducesResponseType<Especie>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById_IActionResult(int id)
        {
            var product = _especieServices.GetEspecie();
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost()]
        public async Task<Especie> PostEspecie(Especie especie)
        {
            await _especieServices.CreateEspecie(especie);

            return especie;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Especie updateEspecie)
        {
            var especie = await _especieServices.GetEspecie(id);

            if (especie is null)
            {
                return NotFound();
            }

            updateEspecie.Id = especie.Id;

            await _especieServices.UpdateEspecie(id, updateEspecie);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _especieServices.GetEspecie(id);

            if (book is null)
            {
                return NotFound();
            }

            await _especieServices.RemoveEspecie(id);

            return NoContent();
        }
    }
}
