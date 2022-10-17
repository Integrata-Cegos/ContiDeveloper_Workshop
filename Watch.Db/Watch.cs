using Watch.Db.Entities;
using Watch.Api;
namespace Watch.Db;
public class WatchDatabaseAccess : IWatchOperations
{
    public int Create(string name, double price)
    {
        var dbContext = new workshopContext();
        var newwatch = new Watch.Db.Entities.Watch();
        newwatch.Name = name;
        newwatch.Price = price;
        dbContext.Watches.Add(newwatch);
        dbContext.SaveChanges();
        return newwatch.Id; 
    }  

    public Watch.Api.Watch FindById(int id)
    {
        var dbContext = new workshopContext();
        return Assemble(dbContext.Watches.Find(id)!);
    }

    public List<Watch.Api.Watch> FindAll()
    {
        var dbContext = new workshopContext();
        return dbContext.Watches.ToList().Select(i => Assemble(i)).ToList();
    }

    public void Update(Watch.Api.Watch entity)
    {
        var dbContext = new workshopContext();
        dbContext.Update(entity);
    }
    public void DeleteById(int id)
    {
        var dbContext = new workshopContext();
        var watch = new Watch.Db.Entities.Watch();
        watch.Id = id;
        dbContext.Attach(watch);
        dbContext.Remove(watch);
        dbContext.SaveChanges();
    }

    private Watch.Api.Watch Assemble(Watch.Db.Entities.Watch entity)
    {
        var watch = new Watch.Api.Watch();
        watch.Id = entity.Id;
        watch.name = entity.Name;
        watch.price = entity.Price;
        return watch;
    }
}