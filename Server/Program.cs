using Instrument.Db;
using Camera.Db;
using Television.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TelevisionDatabaseAccess>(new TelevisionDatabaseAccess());

builder.Services.AddSingleton<InstrumentDatabaseAccess>(new InstrumentDatabaseAccess());
builder.Services.AddSingleton<CameraDatabaseAccess>(new CameraDatabaseAccess());

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
