namespace Notebook.Api;
public class Notebook
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface INotebookOperations
{
    int Create(string name, double price);
    Notebook FindById(int id);
    List<Notebook> FindAll();
    void Update(Notebook entity);
    void DeleteById(int id);
    
}
