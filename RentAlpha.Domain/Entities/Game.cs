using System;

namespace RentAlpha.Domain.Entities
{
  public class Game
  {
    public int GameId { get; set; }
    public string Title { get; set; }
    public int AgeRating { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool Rented { get; set; }
    public DateTime? RentalDate { get; set; }
    public DateTime? DateToDeliver { get; set; }
    public int? FriendId { get; set; }
    public virtual Friend Friend { get; set; }
  }
}
