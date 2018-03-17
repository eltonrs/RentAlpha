using RentAlpha.Domain.Interfaces.Repositories;
using RentAlpha.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;

namespace RentAlpha.Infrastructure.Data.Repositories
{
  public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
  {
    protected RentAlphaContext Db = new RentAlphaContext();

    public void Add(TEntity pObj)
    {
      Db.Set<TEntity>().Add(pObj);
      Db.SaveChanges();
    }

    public DateTime CurrentDateTime()
    {
      return Db.Database.SqlQuery<DateTime>("SELECT GETDATE()").FirstOrDefault();
    }

    public void Dispose()
    {
      Dispose();
    }

    public IEnumerable<TEntity> GetAll()
    {
      return Db.Set<TEntity>().ToList();
    }

    public TEntity GetById(int pId)
    {
      return Db.Set<TEntity>().Find(pId);
    }

    public void Remove(TEntity pObj)
    {
      Db.Set<TEntity>().Remove(pObj);
      Db.SaveChanges();
    }

    public void Update(TEntity pObj)
    {
      // já existe na base de dados
      Db.Entry(pObj).State = EntityState.Modified;
      Db.SaveChanges();
    }
  }
}
