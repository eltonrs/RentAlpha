using RentAlpha.Application.Interfaces;
using RentAlpha.Domain.Entities;
using RentAlpha.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAlpha.Application.Services
{
  public class AppServiceFriend : AppServiceBase<Friend>, IAppServiceFriend
  {
    private readonly IServiceFriend _serviceFriend;

    public AppServiceFriend(IServiceFriend serviceFriend)
      : base(serviceFriend)
    {
      _serviceFriend = serviceFriend;
    }

    //public bool CanRent(Game pGame)
    //{
    //  return _serviceFriend.CanRent(pGame);
    //}

    //public int CountOfGamesRented()
    //{
    //  return _serviceFriend.CountOfGamesRented();
    //}

    //public IEnumerable<Friend> FindAllByFirstName(string pFirstName)
    //{
    //  return _serviceFriend.FindAllByFirstName(pFirstName);
    //}

    //public int LateDeliveries()
    //{
    //  return _serviceFriend.LateDeliveries();
    //}
  }
}
