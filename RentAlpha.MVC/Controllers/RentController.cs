using AutoMapper;
using RentAlpha.Application.Interfaces;
using RentAlpha.Domain.Entities;
using RentAlpha.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace RentAlpha.MVC.Controllers
{
  public class RentController : Controller
  {
    private readonly IAppServiceFriend _appServiceFriend;
    private readonly IAppServiceGame _appServiceGame;

    public RentController(IAppServiceFriend appServiceFriend, IAppServiceGame appServiceGame)
    {
      _appServiceFriend = appServiceFriend;
      _appServiceGame = appServiceGame;
    }

    // GET: Rent
    public ViewResult Index(string searchString, int? page)
    {
      IEnumerable<Friend> friends;
      IEnumerable<Game> games = _appServiceGame.GetAllAvaliableGames().OrderBy(game => game.Title);

      if (searchString != null)
      {
        friends = _appServiceFriend.GetAll().Where(s => s.FirstName.Trim().ToUpper().Contains(searchString.Trim().ToUpper())).OrderBy(friend => friend.FirstName);
        page = 1;
      }
      else
        friends = _appServiceFriend.GetAll().OrderBy(friend => friend.FirstName);

      var friendViewModel = Mapper.Map<IEnumerable<Friend>, IEnumerable<FriendViewModel>>(friends);
      var gameViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games);

      RentViewModel rentViewModel = new RentViewModel
      {
        Friends = friendViewModel,
        Games = gameViewModel,
        PageCount = 5
      };

      int pageNumber = (page ?? 1);

      return View(rentViewModel);
    }

    // GET: Rent/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: Rent/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Rent/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
        try
        {
            // TODO: Add insert logic here

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: Rent/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Rent/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
        try
        {
            // TODO: Add update logic here

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: Rent/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: Rent/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
        try
        {
            // TODO: Add delete logic here

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
  }
}
