using RentAlpha.Domain.Entities;
using RentAlpha.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAlpha.Infrastructure.Data.Repositories
{
  public class RepositoryFriend : RepositoryBase<Friend>, IRepositoryFriend
  {
    //public bool CanRent(Game pGame)
    //{
    //  return Db.Friends.Where(friend => (DateTime.Now.Year - friend.Birthday.Year) < pGame.AgeRating).Count() > 0;
    //}

    //public int CountOfGamesRented()
    //{
    //  throw new NotImplementedException();
    //}

    //public IEnumerable<Friend> FindAllByFirstName(string pFirstName)
    //{
    //  return Db.Friends.Where(friend => friend.FirstName == pFirstName);
    //}

    //public int LateDeliveries()
    //{
    //  throw new NotImplementedException();
    //}
  }
}
