using RentAlpha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAlpha.Application.Interfaces
{
  public interface IAppServiceGame : IAppServiceBase<Game>
  {
    IEnumerable<Game> GetAllAvaliableGames();
    IEnumerable<Game> GetAllRentedGames(int pFriendId);
    void SetGameAsReturned(Game pGame);
    void SetGameAsRented(Game pGame);

    //IEnumerable<Game> GetAllByTitle(string pTitle);
    //IEnumerable<Game> GetAllRented();
    //IEnumerable<Game> GetAllAvaliable();
  }
}
