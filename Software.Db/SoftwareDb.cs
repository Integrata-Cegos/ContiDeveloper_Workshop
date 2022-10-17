using Microsoft.EntityFrameworkCore;
using Software.Api;
using Software.Db.Entity;

namespace Software.Db;
public class SoftwareDataAccess : ISoftwareOperations
{
    SoftwareContext db = new();
    public int Create(string name, double price)
    {
        Api.Software software = new() { name = name, price = price };
        db.Softwares.Add(software);
        db.SaveChanges();
        return (int)software.Id;
    }

    public void DeleteById(int id)
    {
        Api.Software software = db.Softwares.Where(x => x.Id == id).First();
        db.Softwares.Remove(software);
        db.SaveChanges();
    }

    public List<Api.Software> FindAll()
    {
        List<Api.Software> apisoftwares = new();
        var dbsoftwares = db.Softwares.ToList();
        foreach (var dbsoftware in dbsoftwares)
        {
            apisoftwares.Add(new() { Id = dbsoftware.Id, name = dbsoftware.name, price = dbsoftware.price });
        }
        return apisoftwares;
    }

    public Api.Software FindById(int id)
    {
        var dbitem = db.Softwares.Where(x => x.Id == id).First();

        return new() { Id = dbitem.Id, name = dbitem.name, price = dbitem.price };
    }

    public void Update(Api.Software entity)
    {
        var dbitem = db.Softwares.Where(x => x.Id == entity.Id).First();
        dbitem.price = entity.price;
        dbitem.name = entity.name;
        db.SaveChanges();
    }
}
