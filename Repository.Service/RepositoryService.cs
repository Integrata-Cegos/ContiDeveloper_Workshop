using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Repository.Service;

public interface IRepositoryService<T> where T : class, IEntityBase, new()
{
    public void Create(T item);
    public List<T> ListAll();
    public T GetByID(int id);
    public void DeleteByID(int id);
    public void Edit(T item);
}
public class RepositoryService<T> : IRepositoryService<T> where T : class, IEntityBase, new()
{
    private readonly IEntityBaseRepository<T> _repository;
    public RepositoryService(IEntityBaseRepository<T> repository)
    {
        _repository = repository;
    }

    public T GetByID(int id)
    {
        return _repository.GetSingle(id);
    }

    public List<T> ListAll()
    {
        return _repository.GetAll().ToList();
    }

    public void DeleteByID(int id)
    {
        try
        {
            _repository.Delete(_repository.GetSingle(id));
            _repository.Commit();
        }
        catch (Exception)
        {
        }
    }

    public void Edit(T item)
    {
        try
        {
            _repository.Edit(item);
            _repository.Commit();
        }
        catch (Exception)
        {

        }
    }

    public void Create(T item)
    {
        _repository.Add(item);
        _repository.Commit();
        //this.DbContext.Database.EnsureCreated();
    }
}
