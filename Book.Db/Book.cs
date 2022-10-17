using Book.Db.Entities;
using Book.Api;
namespace Book.Db;
public class BookDatabaseAccess : IBooksOperations
{
    public int Create(string name, double price)
    {
        var dbContext = new workshopContext();
        var newbook = new Book.Db.Entities.Book();
        newbook.Name = name;
        newbook.Price = price;
        dbContext.Books.Add(newbook);
        dbContext.SaveChanges();
        return newbook.Id; 
    }  

    public Book.Api.Book FindById(int id)
    {
        var dbContext = new workshopContext();
        return Assemble(dbContext.Books.Find(id)!);
    }

    public List<Book.Api.Book> FindAll()
    {
        var dbContext = new workshopContext();
        return dbContext.Books.ToList().Select(i => Assemble(i)).ToList();
    }

    public void Update(Book.Api.Book entity)
    {
        var dbContext = new workshopContext();
        dbContext.Update(entity);
    }
    public void DeleteById(int id)
    {
        var dbContext = new workshopContext();
        var book = new Book.Db.Entities.Book();
        book.Id = id;
        dbContext.Attach(book);
        dbContext.Remove(book);
        dbContext.SaveChanges();
    }

    private Book.Api.Book Assemble(Book.Db.Entities.Book entity)
    {
        var book = new Book.Api.Book();
        book.Id = entity.Id;
        book.name = entity.Name;
        book.price = entity.Price;
        return book;
    }
}
