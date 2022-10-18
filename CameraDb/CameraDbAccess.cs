using Camera.Api;
using CameraDb.Entities;

namespace CameraDb;

public class CameraDatabaseAccess : ICameraOperations
{
    public int Create(string name, double price)
    {
        var dbContext = new workshopContext();
        var Camera = new CameraDb.Entities.Camera();
        Camera.Name = name;
        Camera.Price = price;
        dbContext.Cameras.Add(Camera);
        dbContext.SaveChanges();
        return Camera.Id;
    }
    public Camera.Api.Camera FindById(int id)
    {
        var dbContext = new workshopContext();
        return Assemble(dbContext.Cameras.Find(id)!);
    }
    public List<Camera.Api.Camera> FindAll()
    {
        var dbContext = new workshopContext();
        return dbContext.Cameras.ToList().Select(i => Assemble(i)).ToList();

    }
    public void Update(Camera.Api.Camera entity)
    {
        var dbContext = new workshopContext();
        dbContext.Update(entity);
    }
    public void DeleteById(int id)
    {
        var dbContext = new workshopContext();
        var Camera = new CameraDb.Entities.Camera();
        Camera.Id = id;
        dbContext.Attach(Camera);
        dbContext.Remove(Camera);
        dbContext.SaveChanges();
    }

    private Camera.Api.Camera Assemble(CameraDb.Entities.Camera entity)
    {
        var Camera = new Camera.Api.Camera();
        Camera.Id = entity.Id;
        Camera.name = entity.Name;
        Camera.price = entity.Price;
        return Camera;
    }
}

