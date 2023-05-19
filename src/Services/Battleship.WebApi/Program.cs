using Battleship.Core.Abstract;
using Battleship.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGameRoomManager, InMemoryGameRoomManager>();
builder.Services.AddSingleton<IPlayerManager, InMemoryPlayerManager>();

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapHub<GameHub>("/hubs/game");

app.Run();
