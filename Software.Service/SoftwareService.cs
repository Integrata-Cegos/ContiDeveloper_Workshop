using Software.Api;

namespace Software.Service;
public class SoftwareService : ISoftwareOperations
{
    int UniqueCounter = 0;
    List<Api.Software> db = new();
    public int Create(string name, double price)
    {
        UniqueCounter++;
        db.Add(new() { Id = UniqueCounter, name = name, price = price }) ;
        return UniqueCounter;
    }

    public void DeleteById(int id)
    {
        db.RemoveAll(x => x.Id == id);
    }

    public List<Api.Software> FindAll()
    {
        return db;
    }

    public Api.Software FindById(int id)
    {
        return db.FindAll(x => x.Id == id).First();
    }

    public void Update(Api.Software entity)
    {
        db.Where(x => x.Id == entity.Id).First().name = entity.name;
        db.Where(x => x.Id == entity.Id).First().price = entity.price;
    }
}
