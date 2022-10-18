using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkShopContext;

namespace WorkShopContext;
public interface IEntityBase
{
    int ID { get; set; }
}
public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
    IQueryable<T> All { get; }
    IQueryable<T> GetAll();
    T GetSingle(int id);
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Delete(T entity);
    void Edit(T entity);
    void Commit();
}
public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
{

    #region Properties

    private WorkShopDBContext dataContext;
    private IDbContextFactory<WorkShopDBContext> _contextFactory;
 
    public EntityBaseRepository(IDbContextFactory<WorkShopDBContext> contextFactory)
    => _contextFactory = contextFactory;

    protected WorkShopDBContext DbContext
    {
        get { return dataContext ?? (dataContext = _contextFactory.CreateDbContext()); }
    }

    #endregion
    public virtual IQueryable<T> GetAll()
    {
        return DbContext.Set<T>();
    }

    public virtual IQueryable<T> All
    {
        get
        {
            return GetAll();
        }
    }
    public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = DbContext.Set<T>();
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return query;
    }
    public T GetSingle(int id)
    {
        return GetAll().FirstOrDefault(x => x.ID == id);
    }
    public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return DbContext.Set<T>().Where(predicate);
    }

    public virtual void Add(T entity)
    {
        EntityEntry<T> dbEntityEntry = DbContext.Entry<T>(entity);
        DbContext.Set<T>().Add(entity);
    }
    public virtual void Edit(T entity)
    {
        EntityEntry<T> dbEntityEntry = DbContext.Entry<T>(entity);
        dbEntityEntry.State = EntityState.Modified;
    }
    public virtual void Delete(T entity)
    {
        EntityEntry<T> dbEntityEntry = DbContext.Entry<T>(entity);
        dbEntityEntry.State = EntityState.Deleted;
    }

    public void Commit()
    {
        //Create Tables in Database
       //RelationalDatabaseCreator databaseCreator =
       //(RelationalDatabaseCreator)DbContext.Database.GetService<IDatabaseCreator>();
       // databaseCreator.CreateTables();
        DbContext.Commit();
    }
}
