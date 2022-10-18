using Instrument.Db.Entities;
using Instrument.Api;
namespace Instrument.Db;
public class InstrumentDatabaseAccess : IInstrumentOperations
{

    public int Create(string name, double price)
    {
        var dbContext = new workshopContext();
        var instrument = new Instrument.Db.Entities.Instrument();
        instrument.Name = name;
        instrument.Price = price;
        dbContext.Instruments.Add(instrument);
        dbContext.SaveChanges();
        return instrument.Id;
    }
    public Instrument.Api.Instrument FindById(int id)
    {
        var dbContext = new workshopContext();
        return Assemble(dbContext.Instruments.Find(id)!);
    }
    public List<Instrument.Api.Instrument> FindAll()
    {
        var dbContext = new workshopContext();
        return dbContext.Instruments.ToList().Select(i => Assemble(i)).ToList();

    }
    public void Update(Instrument.Api.Instrument entity)
    {
        var dbContext = new workshopContext();
        dbContext.Update(entity);
    }
    public void DeleteById(int id)
    {
        var dbContext = new workshopContext();
        var instrument = new Instrument.Db.Entities.Instrument();
        instrument.Id = id;
        dbContext.Attach(instrument);
        dbContext.Remove(instrument);
        dbContext.SaveChanges();
    }

    private Instrument.Api.Instrument Assemble(Instrument.Db.Entities.Instrument entity)
    {
        var instrument = new Instrument.Api.Instrument();
        instrument.Id = entity.Id;
        instrument.name = entity.Name;
        instrument.price = entity.Price;
        return instrument;
    }
}


