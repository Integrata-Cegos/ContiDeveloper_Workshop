namespace WorkShopContext.Models;
public class TomSoftware
{
    public int? Id {get; set;}
    public string? Name {get; set;}

    public double? Price {get; set;}
}

public interface ITomSoftwareOperations
{
    int Create(string name, double price);
    TomSoftware FindById(int id);
    List<TomSoftware> FindAll();
    void Update(TomSoftware entity);
    void DeleteById(int id);
    
}
