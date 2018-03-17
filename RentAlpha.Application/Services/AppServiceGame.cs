using RentAlpha.Application.Interfaces;
using RentAlpha.Domain.Entities;
using RentAlpha.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace RentAlpha.Application.Services
{
  public class AppServiceGame : AppServiceBase<Game>, IAppServiceGame
  {
    private readonly IServiceGame _serviceGame;

    public AppServiceGame(IServiceGame serviceGame)
      : base(serviceGame)
    {
      _serviceGame = serviceGame;
    }

    public IEnumerable<Game> GetAllAvaliableGames()
    {
      return _serviceGame.GetAllAvaliableGames();
    }

    public IEnumerable<Game> GetAllRentedGames(int pFriendId)
    {
      return _serviceGame.GetAllRentedGames(pFriendId);
    }

    public void SetGameAsRented(Game pGame)
    {
      _serviceGame.SetGameAsRented(pGame);
    }

    public void SetGameAsReturned(Game pGame)
    {
      _serviceGame.SetGameAsReturned(pGame);
    }

    //public IEnumerable<Game> GetAllAvaliable()
    //{
    //  return _serviceGame.GetAllAvaliable();
    //}

    //public IEnumerable<Game> GetAllByTitle(string pTitle)
    //{
    //  return _serviceGame.GetAllByTitle(pTitle);
    //}

    //public IEnumerable<Game> GetAllRented()
    //{
    //  return _serviceGame.GetAllRented();
    //}
  }
}
