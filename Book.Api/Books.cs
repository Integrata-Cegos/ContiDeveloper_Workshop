namespace Book.Api;
public class Book
{
    public int? Id {get; set;}
    public string? name {get; set;}

    public double? price {get; set;}
}

public interface IBooksOperations
{
    int Create(string name, double price);
    Book FindById(int id);
    List<Book> FindAll();
    void Update(Book entity);
    void DeleteById(int id);
    
}
