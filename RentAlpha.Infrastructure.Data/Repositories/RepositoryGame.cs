using RentAlpha.Domain.Entities;
using RentAlpha.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RentAlpha.Infrastructure.Data.Repositories
{
  public class RepositoryGame : RepositoryBase<Game>, IRepositoryGame
  {
    public IEnumerable<Game> GetAllAvaliableGames()
    {
      return Db.Games.Where(game => !game.Rented);
    }

    public IEnumerable<Game> GetAllRentedGames(int pFriendId)
    {
      return Db.Games.Where(game => game.FriendId == pFriendId);
    }

    public void SetGameAsRented(Game pGame)
    {
      pGame.Rented = true;
      pGame.RentalDate = CurrentDateTime();
      pGame.DateToDeliver?.AddDays(3);
      Update(pGame);
    }

    public void SetGameAsReturned(Game pGame)
    {
      Update(pGame);
    }

    //public IEnumerable<Game> FindAllByTitle(string pTitle)
    //{
    //  return Db.Games.Where(game => game.Title == pTitle);
    //}
  }
}
