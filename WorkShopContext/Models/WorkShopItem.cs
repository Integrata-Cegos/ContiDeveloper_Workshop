namespace WorkShopContext.Models;
public class WorkShopItem : IEntityBase
{
    public int ID { get; set; }
    public string? Name {get; set;}

    public double? Price {get; set;}
}

public interface IWorkShopItemOperations
{
    int Create(string name, double price);
    WorkShopItem FindById(int id);
    List<WorkShopItem> FindAll();
    void Update(WorkShopItem entity);
    void DeleteById(int id);
    
}
