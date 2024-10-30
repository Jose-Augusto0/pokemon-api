using FavoritesPokemons.Models;
using Microsoft.EntityFrameworkCore;

namespace FavoritesPokemons.Data
{
    public class FavoritesDBContext : DbContext
    {
        public FavoritesDBContext(DbContextOptions<FavoritesDBContext> options)
            : base(options)
        {
        }
        public DbSet<FavoriteModel> Favorites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FavoriteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
