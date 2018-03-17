using RentAlpha.Domain.Entities;
using RentAlpha.Domain.Interfaces.Repositories;
using RentAlpha.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAlpha.Domain.Services
{
  public class ServiceFriend : ServiceBase<Friend>, IServiceFriend
  {
    private readonly IRepositoryFriend _repositoryFriend;

    public ServiceFriend(IRepositoryFriend repositoryFriend)
      : base(repositoryFriend)
    {
      _repositoryFriend = repositoryFriend;
    }

    //public bool CanRent(Game pGame)
    //{
    //  return _repositoryFriend.CanRent(pGame);
    //}

    //public int CountOfGamesRented()
    //{
    //  return _repositoryFriend.CountOfGamesRented();
    //}

    //public IEnumerable<Friend> FindAllByFirstName(string pFirstName)
    //{
    //  return _repositoryFriend.FindAllByFirstName(pFirstName);
    //}

    //public int LateDeliveries()
    //{
    //  return _repositoryFriend.LateDeliveries();
    //}
  }
}
