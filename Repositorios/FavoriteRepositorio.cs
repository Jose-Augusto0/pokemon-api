﻿using FavoritesPokemons.Data;
using Microsoft.EntityFrameworkCore;
using FavoritesPokemons.Models;
using FavoritesPokemons.Repositorios.Interface;

namespace FavoritesPokemons.Repositorios
{
    public class FavoriteRepositorio : IFavoriteRepositorio
    {
        private readonly FavoritesDBContext _DbContext;

        public FavoriteRepositorio(FavoritesDBContext favoritesDBContext)
        {
            _DbContext = favoritesDBContext;
        }

        public async Task<List<FavoriteModel>> GetAllPokemons()
        {
            return await _DbContext.Favorites.ToListAsync();
        }

        public async Task<FavoriteModel> Send(FavoriteModel favorite)
        {
            await _DbContext.Favorites.AddAsync(favorite);
            await _DbContext.SaveChangesAsync();
            return favorite;
        }
    }
}