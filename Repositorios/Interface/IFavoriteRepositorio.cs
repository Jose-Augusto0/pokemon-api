using FavoritesPokemons.Models;

namespace FavoritesPokemons.Repositorios.Interface
{
    public interface IFavoriteRepositorio
    {
        Task<List<FavoriteModel>> GetAllPokemons();
        Task<FavoriteModel> Send(FavoriteModel usuario);

    }
}
