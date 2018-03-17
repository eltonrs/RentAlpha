using RentAlpha.Domain.Entities;
using System.Collections.Generic;

namespace RentAlpha.Domain.Interfaces.Services
{
  public interface IServiceGame : IServiceBase<Game>
  {
    void SetGameAsReturned(Game pGame);
    void SetGameAsRented(Game pGame);

    IEnumerable<Game> GetAllRentedGames(int pFriendId);

    IEnumerable<Game> GetAllAvaliableGames();

    //IEnumerable<Game> GetAllByTitle(string pTitle);
    //IEnumerable<Game> GetAllRented();
    //IEnumerable<Game> GetAllAvaliable();
  }
}
