using FavoritesPokemons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoritesPokemons.Data
{
    public class FavoriteMap : IEntityTypeConfiguration<FavoriteModel>
    {
        public void Configure(EntityTypeBuilder<FavoriteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
