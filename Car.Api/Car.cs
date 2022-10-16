namespace Car.Api;
public class Car
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface ICarOperations
{
    int Create(string name, double price);
    Car FindById(int id);
    List<Car> FindAll();
    void Update(Car entity);
    void DeleteById(int id);
    
}
