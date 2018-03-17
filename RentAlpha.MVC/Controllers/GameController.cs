using AutoMapper;
using RentAlpha.Application.Interfaces;
using RentAlpha.Domain.Entities;
using RentAlpha.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RentAlpha.MVC.Controllers
{
  public class GameController : Controller
  {
    private readonly IAppServiceGame _appServiceGame;

    public GameController(IAppServiceGame appServiceGame)
    {
      _appServiceGame = appServiceGame;
    }

    // GET: Game
    public ActionResult Index()
    {
      var game = _appServiceGame.GetAll();
      var gameViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(game);

      return View(gameViewModel);
    }

    [HttpPost]
    public ActionResult ReturnGame(int id)
    {
      Game game = _appServiceGame.GetById(id);

      game.DateToDeliver = null;
      game.FriendId = null;
      game.RentalDate = null;
      game.Rented = false;

      _appServiceGame.Update(game);

      return RedirectToAction("Details", "Friend", id);
    }

    [HttpPost]
    public ActionResult SetGameAsRented(int pGameId, int pFriendId)
    {
      Game game = _appServiceGame.GetById(pGameId);
      game.FriendId = pFriendId;
      _appServiceGame.SetGameAsRented(game);

      return RedirectToAction("Index", "Rent");
    }

    // GET: Game/Details/5
    public ActionResult Details(int id)
    {
      var games = _appServiceGame.GetById(id);
      var gameViewModel = Mapper.Map<Game, GameViewModel>(games);

      return View(gameViewModel);
    }

    // GET: Game/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Game/Create
    [HttpPost]
    [ValidateAntiForgeryToken] // Previne ataques CSRF
    public ActionResult Create(GameViewModel pGameViewModel)
    {
      if (ModelState.IsValid)
      {
        var gameDomain = Mapper.Map<GameViewModel, Game>(pGameViewModel);
        _appServiceGame.Add(gameDomain);

        return RedirectToAction("Index");
      }

      return View(pGameViewModel);
    }

    // GET: Game/Edit/5
    public ActionResult Edit(int id)
    {
      var game = _appServiceGame.GetById(id);
      var gameViewModel = Mapper.Map<Game, GameViewModel>(game);

      return View(gameViewModel);
    }

    // POST: Game/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken] // Previne ataques CSRF
    public ActionResult Edit(GameViewModel pGameViewModel)
    {
      if (ModelState.IsValid)
      {
        var gameDomain = Mapper.Map<GameViewModel, Game>(pGameViewModel);
        _appServiceGame.Update(gameDomain);

        return RedirectToAction("Index");
      }

      return View(pGameViewModel);
    }

    // GET: Game/Delete/5
    public ActionResult Delete(int id)
    {
      var game = _appServiceGame.GetById(id);
      var gameViewModel = Mapper.Map<Game, GameViewModel>(game);

      return View(gameViewModel);
    }

    // POST: Game/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken] // Previne ataques CSRF
    public ActionResult Delete(int id, FormCollection collection)
    {
      var game = _appServiceGame.GetById(id);
      _appServiceGame.Remove(game);

      return RedirectToAction("Index");
    }
  }
}
