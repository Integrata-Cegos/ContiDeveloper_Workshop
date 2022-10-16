namespace Game.Api;
public class Game
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface IGameOperations
{
    int Create(string name, double price);
    Game FindById(int id);
    List<Game> FindAll();
    void Update(Game entity);
    void DeleteById(int id);
    
}
