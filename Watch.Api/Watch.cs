namespace Watch.Api;
public class Watch
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface IWatchOperations
{
    int Create(string name, double price);
    Watch FindById(int id);
    List<Watch> FindAll();
    void Update(Watch entity);
    void DeleteById(int id);
    
}
