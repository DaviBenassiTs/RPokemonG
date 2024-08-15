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

        [HttpGet]
        public async Task<List<Ficha>> GetFichas()
            => await _fichaServices.GetAsync();

        [HttpPost]
        public async Task<Ficha> PostFicha(Ficha ficha)
        {
            await _fichaServices.CreateAsync(ficha);

            return ficha;
        }
    }
}
