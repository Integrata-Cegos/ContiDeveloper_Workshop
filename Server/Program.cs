using Instrument.Db;
using Instrument.Api;
using Camera.Db;
using Camera.Api;
using Television.Db;
using Television.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITelevisionOperations>(new TelevisionDatabaseAccess());
builder.Services.AddSingleton<IInstrumentOperations>(new InstrumentDatabaseAccess());
builder.Services.AddSingleton<ICameraOperations>(new CameraDatabaseAccess());

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
