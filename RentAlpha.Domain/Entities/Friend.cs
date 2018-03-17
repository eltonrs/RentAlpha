using System;
using System.Collections.Generic;
using System.Linq;

namespace RentAlpha.Domain.Entities
{
  public class Friend
  {
    public int FriendId { get; set; }
    public string FirstName { get; set; }
    public string LastaName { get; set; }
    public string NickName { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public DateTime CreateDate { get; set; }
    public virtual IEnumerable<Game> GamesRented { get; set; }

    //public bool LateDeliveries()
    //{
    //  return (this.GamesRented != null && this.GamesRented.Where(game => game.DateToDeliver.Date < DateTime.Now.Date).Count() > 0);
    //}

    //public bool CanRent(Game pGame)
    //{
    //  return (this.Birthday.Year >= pGame.AgeRating);
    //}

    //public int CountOfGamesRented()
    //{
    //  return (this.GamesRented == null ? 0 : this.GamesRented.Count());
    //}
  }
}
