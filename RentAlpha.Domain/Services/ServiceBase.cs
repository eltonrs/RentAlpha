using RentAlpha.Domain.Interfaces.Repositories;
using RentAlpha.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace RentAlpha.Domain.Services
{
  public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
  {
    private readonly IRepositoryBase<TEntity> _repositoryBase;

    public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
    {
      _repositoryBase = repositoryBase;
    }

    public void Add(TEntity pObj)
    {
      _repositoryBase.Add(pObj);
    }

    public void Dispose()
    {
      _repositoryBase.Dispose();
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _repositoryBase.GetAll();
    }

    public TEntity GetById(int pId)
    {
      return _repositoryBase.GetById(pId);
    }

    public void Remove(TEntity pObj)
    {
      _repositoryBase.Remove(pObj);
    }

    public void Update(TEntity pObj)
    {
      _repositoryBase.Update(pObj);
    }
  }
}
