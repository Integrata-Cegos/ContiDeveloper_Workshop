using Television.Api;
using Television.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Television.Db;

public class TelevisionDatabaseAccess : ITelevisionOperations
{
    public int Create(string name, double price)
    {
        var dbContext = new workshopContext();
        var television = new Television.Db.Entities.Television();
        television.Name = name;
        television.Price = price;
        dbContext.Televisions.Add(television);
        dbContext.SaveChanges();
        return television.Id;
    }

    public Television.Api.Television FindById(int id)
    {
        var dbContext = new workshopContext();
        var result = dbContext.Televisions.FromSqlRaw("select * from Televisions where id = @id").Single();
        return ChangeClass(result);
    }

    public List<Television.Api.Television> FindAll()
    {
        var dbContext = new workshopContext();
        return dbContext.Televisions.ToList().Select(t => ChangeClass(t)).ToList();
    }

    public void Update(Television.Api.Television entity)
    {
        var dbContext = new workshopContext();
        dbContext.Update(entity);
    }

    public void DeleteById(int id)
    {
        var dbContext = new workshopContext();
        var television = new Television.Db.Entities.Television();
        television.Id = id;
        dbContext.Attach(television);
        dbContext.Remove(television);
        dbContext.SaveChanges();
    }

    private Television.Api.Television ChangeClass (Television.Db.Entities.Television entity)
    {
        var television = new Television.Api.Television();
        television.Id = entity.Id;
        television.name = entity.Name;
        television.price = entity.Price;
        return television;
    }
}
