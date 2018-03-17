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
  public class ServiceGame : ServiceBase<Game>, IServiceGame
  {
    private readonly IRepositoryGame _repositoryGame;

    public ServiceGame(IRepositoryGame repositoryGame)
      : base(repositoryGame)
    {
      _repositoryGame = repositoryGame;
    }

    public IEnumerable<Game> GetAllAvaliableGames()
    {
      return _repositoryGame.GetAllAvaliableGames();
    }

    public IEnumerable<Game> GetAllRentedGames(int pFriendId)
    {
      return _repositoryGame.GetAllRentedGames(pFriendId);
    }

    public void SetGameAsRented(Game pGame)
    {
      _repositoryGame.SetGameAsRented(pGame);
    }

    public void SetGameAsReturned(Game pGame)
    {
      _repositoryGame.SetGameAsReturned(pGame);
    }
  }
}
