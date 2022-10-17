using Instrument.Api;
namespace Instrument.Impl;
public class InstrumentsManager: IInstrumentOperations
{
    private int counter = 0;
    private Dictionary<int, Instrument.Api.Instrument> instruments = new Dictionary<int, Instrument.Api.Instrument>();
    public int Create(string name, double price)
    {
        var newInstrument = new Instrument.Api.Instrument();
        newInstrument.Id = ++counter;
        newInstrument.name = name;
        newInstrument.price = price;
        instruments[counter] = newInstrument;
        return counter;
    }
    public Instrument.Api.Instrument FindById(int id)    
    {
        return instruments[id];
    }

    public List<Instrument.Api.Instrument> FindAll()
    {
        return instruments.Values.ToList();
    }
    public void Update(Instrument.Api.Instrument entity)
    {
        instruments[(int)entity.Id!] = entity;
    }
    public void DeleteById(int id)
    {
        instruments.Remove(id);
    }
    

}
