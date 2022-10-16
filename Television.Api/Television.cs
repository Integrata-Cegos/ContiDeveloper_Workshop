namespace Television.Api;
public class Television
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface ITelevisionOperations
{
    int Create(string name, double price);
    Television FindById(int id);
    List<Television> FindAll();
    void Update(Television entity);
    void DeleteById(int id);
    
}
