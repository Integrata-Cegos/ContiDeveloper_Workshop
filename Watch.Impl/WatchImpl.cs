using Watch.Api;
namespace Watch.Impl;
public class WatchOperations : IWatchOperations
{
    private static int counter = 0;
    private Dictionary<int, Watch.Api.Watch> watches = new Dictionary<int, Watch.Api.Watch>();
    public int Create(string name, double price)
    {
       var newWatch = new Watch.Api.Watch();
        newWatch.Id = counter++;
        newWatch.name = name;
        newWatch.price = price;
        watches[counter] = newWatch;
        return counter;
    }
    public Watch.Api.Watch FindById(int id)
    {
        return watches[id];
    }
    public List<Watch.Api.Watch> FindAll()
    {
        return watches.Select(e => e.Value).ToList();
    }
    public void Update(Watch.Api.Watch entity)
    {
        watches[(int)entity.Id!] = entity;
    }
    public void DeleteById(int id)
    {
        watches.Remove(id);
    }
}
