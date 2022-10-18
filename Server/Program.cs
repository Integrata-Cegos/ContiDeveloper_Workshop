using Car.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using Software.Service;
using TomSoftware.Service;
using WorkShopContext;
using WorkShopContext.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionstring = "Data Source=h2908727.stratoserver.net;Initial Catalog=workshop;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
builder.Services.AddDbContextFactory<WorkShopDBContext>(o => o.UseSqlServer(connectionstring));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new SoftwareService());
builder.Services.AddSingleton(new CarService());
builder.Services.AddScoped<IEntityBaseRepository<WorkShopItem>, EntityBaseRepository<WorkShopItem>>();
builder.Services.AddSingleton<ITomSoftwareService, TomSoftwareService>();


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
