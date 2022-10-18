using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    #region Properties OLD
    ////private TContext _dataContext;
    ////private readonly IDbContextFactory<TContext> _contextFactory;
    //DbContext _dbContext;
    //private readonly DbSet<T> _dbSet;
    //public RepositoryBase(IDbContextFactory<TContext> contextFactory)
    //{
    //    _dbContext = contextFactory.CreateDbContext();
    //    //_dbSet = DbSet<T>;
    //    //_dbContext = _contextFactory.CreateDbContext();
    //}


    #endregion
    #region Implementation OLD
    //public virtual void Add(T entity)
    //{
    //    _dbSet.Add(entity);
    //}

    //public virtual void Update(T entity)
    //{
    //    _dbSet.Attach(entity);
    //    _dbContext.Entry(entity).State = EntityState.Modified;
    //}

    //public virtual void Delete(T entity)
    //{
    //    _dbSet.Remove(entity);
    //}

    //public virtual void Delete(Expression<Func<T, bool>> where)
    //{
    //    IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
    //    foreach (T obj in objects)
    //        _dbSet.Remove(obj);
    //}

    //public virtual T GetById(int id)
    //{
    //    return _dbSet.Find(id);
    //}

    //public virtual IEnumerable<T> GetAll()
    //{
    //    return _dbSet.ToList();
    //}

    //public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
    //{
    //    return _dbSet.Where(where).ToList();
    //}

    //public T Get(Expression<Func<T, bool>> where)
    //{
    //    return _dbSet.Where(where).FirstOrDefault<T>();
    //}

    #endregion

    #region Properties

    private WorkShopDBContext dataContext;
    private IDbContextFactory<WorkShopDBContext> _contextFactory;
 
    public EntityBaseRepository(IDbContextFactory<WorkShopDBContext> contextFactory)
    => _contextFactory = contextFactory;

    protected WorkShopDBContext DbContext
    {
        get { return dataContext ?? (dataContext = _contextFactory.CreateDbContext()); }
    }
    //public EntityBaseRepository(IDbContextFactory<WorkShopDBContext> dbFactory)
    //{
    //    DbFactory = dbFactory;
    //}
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
        DbContext.Commit();
    }
}
