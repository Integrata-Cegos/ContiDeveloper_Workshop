namespace Instrument.Api;
public class Instrument
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface IInstrumentOperations
{
    int Create(string name, double price);
    Instrument FindById(int id);
    List<Instrument> FindAll();
    void Update(Instrument entity);
    void DeleteById(int id);
    
}
