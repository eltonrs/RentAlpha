using RentAlpha.Domain.Entities;
using System.Collections.Generic;

namespace RentAlpha.MVC.ViewModels
{
  public class RentViewModel
  {
    public IEnumerable<FriendViewModel> Friends { get; set; }
    public IEnumerable<GameViewModel> Games { get; set; }
    public int PageCount { get; set; }
  }
}