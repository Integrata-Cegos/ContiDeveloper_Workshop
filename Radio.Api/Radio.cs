namespace Radio.Api;
public class Radio
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface IRadioOperations
{
    int Create(string name, double price);
    Radio FindById(int id);
    List<Radio> FindAll();
    void Update(Radio entity);
    void DeleteById(int id);
    
}
