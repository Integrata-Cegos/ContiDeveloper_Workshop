namespace Dvd.Api;
public class Dvd
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}


public interface IDvdOperations
{
    int Create(string name, double price);
    Dvd FindById(int id);
    List<Dvd> FindAll();
    void Update(Dvd entity);
    void DeleteById(int id);
    
}
