namespace Software.Api;
public class Software
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface ISoftwareOperations
{
    int Create(string name, double price);
    Software FindById(int id);
    List<Software> FindAll();
    void Update(Software entity);
    void DeleteById(int id);
    
}
