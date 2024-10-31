using FavoritesPokemons.Models;
using FavoritesPokemons.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavoritesPokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteRepositorio _favoriteRepositorio;

        public FavoritesController(IFavoriteRepositorio favoriteRepositorio)
        {
            _favoriteRepositorio = favoriteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<FavoriteModel>>> GetAllPokemons()
        {
            List<FavoriteModel> favotites = await _favoriteRepositorio.GetAllPokemons();
            return Ok(favotites);
        }
        [HttpPost]
        public async Task<ActionResult<FavoriteModel>> Send([FromBody] FavoriteModel favoriteMolde)
        {
            FavoriteModel favorites = await _favoriteRepositorio.Send(favoriteMolde);
            return Ok(favorites);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<FavoriteModel>> Remove(int id)
        {
            bool apagado = await _favoriteRepositorio.Remove(id);
            return Ok(apagado);
        }

    }
}
