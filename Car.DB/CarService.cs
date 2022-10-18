using Microsoft.EntityFrameworkCore;
using Car.Api;

namespace Car.DB;
public class CarService : ICarOperations
{
    CarContext db = new();
    public int Create(string name, double price)
    {
        Car car = new() { Name = name, Price = price };
        db.Cars.Add(car);
        db.SaveChanges();
        return car.Id;
    }

    public void DeleteById(int id)
    {
        Car software = db.Cars.Where(x => x.Id == id).First();
        db.Cars.Remove(software);
        db.SaveChanges();
    }

    public List<Api.Car> FindAll()
    {
        List<Api.Car> apisoftwares = new();
        var dbcars = db.Cars.ToList();
        foreach (var dbcar in dbcars)
        {
            apisoftwares.Add(new() { Id = dbcar.Id, name = dbcar.Name, price = dbcar.Price });
        }
        return apisoftwares;
    }

    public Api.Car FindById(int id)
    {
        var dbitem = db.Cars.Where(x => x.Id == id).First();

        return new() { Id = dbitem.Id, name = dbitem.Name, price = dbitem.Price };
    }

    public void Update(Api.Car entity)
    {
        var dbitem = db.Cars.Where(x => x.Id == entity.Id).First();
        dbitem.Price = entity.price;
        dbitem.Name = entity.name;
        db.SaveChanges();
    }
}
