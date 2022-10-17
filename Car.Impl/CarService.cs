using Car.Api;
namespace Car.Impl;
public class CarService:  ICarOperations
{

    Dictionary<int,Car.Api.Car> _cars = new Dictionary<int, Car.Api.Car>();
    int _nextCarId = 0;
    public int Create(string name, double price){
        var car = new Car.Api.Car{
            Id = _nextCarId++,
            name = name,
            price = price
        };
        _cars.Add((int)car.Id,car);
        return (int)car.Id;
    }
    public Car.Api.Car FindById(int id){
        return _cars[id];

    }
    public List<Car.Api.Car> FindAll(){
        return _cars.Values.ToList();
    }
    public void Update(Car.Api.Car entity){
        if(entity.Id == null||!_cars.ContainsKey((int)entity.Id)){
            throw new Exception("No Car with this ID!");
        }
        _cars[(int)entity.Id] = entity;
    }
    public void DeleteById(int id){
        if(!_cars.ContainsKey(id)){
            return;
        }
        _cars.Remove(id);
    }
    
}
