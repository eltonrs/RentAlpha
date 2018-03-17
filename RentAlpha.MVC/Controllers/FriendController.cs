using AutoMapper;
using RentAlpha.Application.Interfaces;
using RentAlpha.Domain.Entities;
using RentAlpha.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RentAlpha.MVC.Controllers
{
  public class FriendController : Controller
  {
    private readonly IAppServiceFriend _appServiceFriend;
    private readonly IAppServiceGame _appServiceGame;

    public FriendController(IAppServiceFriend appServiceFriend, IAppServiceGame appServiceGame)
    {
      _appServiceFriend = appServiceFriend;
      _appServiceGame = appServiceGame;
    }

    // GET: Friend
    public ActionResult Index()
    {
      var friends = _appServiceFriend.GetAll().OrderBy(friend => friend.FirstName);
      var friendViewModel = Mapper.Map<IEnumerable<Friend>, IEnumerable< FriendViewModel>>(friends);

      return View(friendViewModel);
    }

    // GET: Friend/Details/5
    public ActionResult Details(int id)
    {
      var friend = _appServiceFriend.GetById(id);
      var friendViewModel = Mapper.Map<Friend, FriendViewModel>(friend);

      PopulateRentedGames(friendViewModel);

      return View(friendViewModel);
    }

    private void PopulateRentedGames(FriendViewModel pFriend)
    {
      var rentedGamesDomain = _appServiceGame.GetAllRentedGames(pFriend.FriendId);
      var rentedGamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(rentedGamesDomain);

      pFriend.Games = rentedGamesViewModel;
    }

    // GET: Friend/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Friend/Create
    [HttpPost]
    [ValidateAntiForgeryToken] // Previne ataques CSRF
    public ActionResult Create(FriendViewModel pFriendViewModel)
    {
      if (ModelState.IsValid)
      {
        var friendDomain = Mapper.Map<FriendViewModel, Friend>(pFriendViewModel);
        _appServiceFriend.Add(friendDomain);

        return RedirectToAction("Index");
      }

      return View(pFriendViewModel);
    }

    // GET: Friend/Edit/5
    public ActionResult Edit(int id)
    {
      var friend = _appServiceFriend.GetById(id);
      var friendViewModel = Mapper.Map<Friend, FriendViewModel>(friend);

      return View(friendViewModel);
    }

    // POST: Friend/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken] // Previne ataques CSRF
    public ActionResult Edit(FriendViewModel pFriendViewModel)
    {
      if (ModelState.IsValid)
      {
        var friendDomain = Mapper.Map<FriendViewModel, Friend>(pFriendViewModel);
        _appServiceFriend.Update(friendDomain);

        return RedirectToAction("Index");
      }

      return View(pFriendViewModel);
    }

    // GET: Friend/Delete/5
    public ActionResult Delete(int id)
    {
      var friend = _appServiceFriend.GetById(id);
      var friendViewModel = Mapper.Map<Friend, FriendViewModel>(friend);

      return View(friendViewModel);
    }

    // POST: Friend/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken] // Previne ataques CSRF
    public ActionResult DeleteConfirmed(int id)
    {
      var friend = _appServiceFriend.GetById(id);
      _appServiceFriend.Remove(friend);

      return RedirectToAction("Index");
    }
  }
}
