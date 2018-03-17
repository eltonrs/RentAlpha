using RentAlpha.Application.Interfaces;
using RentAlpha.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAlpha.Application.Services
{
  public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
  {
    private readonly IServiceBase<TEntity> _serviceBase;

    public AppServiceBase(IServiceBase<TEntity> serviceBase)
    {
      _serviceBase = serviceBase;
    }

    public void Add(TEntity pObj)
    {
      _serviceBase.Add(pObj);
    }

    public void Dispose()
    {
      _serviceBase.Dispose();
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _serviceBase.GetAll();
    }

    public TEntity GetById(int pId)
    {
      return _serviceBase.GetById(pId);
    }

    public void Remove(TEntity pObj)
    {
      _serviceBase.Remove(pObj);
    }

    public void Update(TEntity pObj)
    {
      _serviceBase.Update(pObj);
    }
  }
}
