namespace Camera.Api;
public class Camera
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface ICameraOperations
{
    int Create(string name, double price);
    Camera FindById(int id);
    List<Camera> FindAll();
    void Update(Camera entity);
    void DeleteById(int id);
    
}
