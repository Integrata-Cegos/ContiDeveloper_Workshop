namespace Cd.Api;
public class Cd
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface ICdOperations
{
    int Create(string name, double price);
    Cd FindById(int id);
    List<Cd> FindAll();
    void Update(Cd entity);
    void DeleteById(int id);
    
}
