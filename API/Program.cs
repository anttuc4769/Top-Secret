using API.MockActions;
using API.Repositories;
using API.Repositories.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: Move these to a different file
#region My Services

builder.Services.AddDbContext<PokemanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PokemanDb")));

builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();

builder.Services.AddTransient<IDataContextService, DataContextService>();
builder.Services.AddTransient<IActions, Actions>();
builder.Services.AddSingleton<IProcessFileService, ProcessPokemonFileService>();
builder.Services.AddTransient<IUploadFileService, UploadPokemonFileService>();
builder.Services.AddTransient<IPokemonService, PokemonService>();

#endregion

var app = builder.Build();

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

