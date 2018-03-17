using RentAlpha.Domain.Entities;
using System.Collections.Generic;

namespace RentAlpha.Domain.Interfaces.Repositories
{
  public interface IRepositoryGame : IRepositoryBase<Game>
  {
    IEnumerable<Game> GetAllRentedGames(int pFriendId);
    IEnumerable<Game> GetAllAvaliableGames();
    void SetGameAsReturned(Game pGame);
    void SetGameAsRented(Game pGame);

    //IEnumerable<Game> FindAllByTitle(string pTitle);
  }
}
