using FavoritesPokemons.Data;
using FavoritesPokemons.Repositorios;
using FavoritesPokemons.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FavoritesDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DataBase"),
        new MySqlServerVersion(new Version(8, 0, 32))
    ));

builder.Services.AddScoped<IFavoriteRepositorio, FavoriteRepositorio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigemAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("PermitirOrigemAngular");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
