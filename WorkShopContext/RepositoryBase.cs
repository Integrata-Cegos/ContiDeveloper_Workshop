using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopContext;
//public abstract class RepositoryBase<T, TContext> where T : class where TContext : DbContext, new()
//{
//    #region Properties
//    private TContext _dataContext;
//    private readonly DbSet<T> _dbSet;

//    protected IDbFactory<TContext> DbFactory
//    {
//        get;
//        private set;
//    }

//    protected TContext DbContext
//    {
//        get { return _dataContext ?? (_dataContext = this.DbFactory.Init()); }
//    }
//    #endregion

//    protected RepositoryBase(IDbFactory<TContext> dbFactory)
//    {
//        DbFactory = dbFactory;
//        _dbSet = DbContext.Set<T>();
//    }

//    #region Implementation
//    public virtual void Add(T entity)
//    {
//        _dbSet.Add(entity);
//    }

//    public virtual void Update(T entity)
//    {
//        _dbSet.Attach(entity);
//        _dataContext.Entry(entity).State = EntityState.Modified;
//    }

//    public virtual void Delete(T entity)
//    {
//        _dbSet.Remove(entity);
//    }

//    public virtual void Delete(Expression<Func<T, bool>> where)
//    {
//        IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
//        foreach (T obj in objects)
//            _dbSet.Remove(obj);
//    }

//    public virtual T GetById(int id)
//    {
//        return _dbSet.Find(id);
//    }

//    public virtual IEnumerable<T> GetAll()
//    {
//        return _dbSet.ToList();
//    }

//    public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
//    {
//        return _dbSet.Where(where).ToList();
//    }

//    public T Get(Expression<Func<T, bool>> where)
//    {
//        return _dbSet.Where(where).FirstOrDefault<T>();
//    }

//    #endregion

//}
