
using Camera.Api;
using CameraDb;
using Instrument.Api;
using Instrument.Db;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICameraOperations>(new CameraDatabaseAccess());
builder.Services.AddSingleton<IInstrumentOperations>(new InstrumentDatabaseAccess());
builder.Services.AddSingleton<Car.Api.ICarOperations>(new Car.DB.CarService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
