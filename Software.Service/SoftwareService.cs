using Microsoft.EntityFrameworkCore;
using Software.Api;

namespace Software.Service;
public class SoftwareService : ISoftwareOperations
{
    SoftwareContext db = new();
    public int Create(string name, double price)
    {
        Software software = new() { Name = name, Price = price };
        db.Softwares.Add(software);
        db.SaveChanges();
        return software.Id;
    }

    public void DeleteById(int id)
    {
        Software software = db.Softwares.Where(x => x.Id == id).First();
        db.Softwares.Remove(software);
        db.SaveChanges();
    }

    public List<Api.Software> FindAll()
    {
        List<Api.Software> apisoftwares = new();
        var dbsoftwares = db.Softwares.ToList();
        foreach (var dbsoftware in dbsoftwares)
        {
            apisoftwares.Add(new() { Id = dbsoftware.Id, name = dbsoftware.Name, price = dbsoftware.Price });
        }
        return apisoftwares;
    }

    public Api.Software FindById(int id)
    {
        var dbitem = db.Softwares.Where(x => x.Id == id).First();

        return new() { Id = dbitem.Id, name = dbitem.Name, price = dbitem.Price };
    }

    public void Update(Api.Software entity)
    {
        var dbitem = db.Softwares.Where(x => x.Id == entity.Id).First();
        dbitem.Price = entity.price;
        dbitem.Name = entity.name;
        db.SaveChanges();
    }
}
