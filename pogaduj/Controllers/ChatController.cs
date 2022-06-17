using Microsoft.AspNetCore.Mvc;
using pogaduj.Data;
using pogaduj.Models;
using pogaduj.Repository;

namespace pogaduj.Controllers
{
    public class ChatController : Controller
    {
        private readonly IMessages _repository;
        private readonly ApplicationDbContext _applicationDbContext;
        public ChatController(IMessages repository, ApplicationDbContext applicationDbContext)
        {
            _repository = repository;
            _applicationDbContext = applicationDbContext;
        }
        //public IActionResult Index(int id)
        //{
        //    _applicationDbContext.Rooms.ToList();
        //    var room = _applicationDbContext.Rooms.Find(id);

        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    //var messages = _repository.GetAll();
        //    return View(room);
        //}

        public IActionResult Index(int id)
        {
            id++;
            _applicationDbContext.Rooms.ToList();
            var room = _applicationDbContext.Rooms.Find(id);

            if (room.User1 == false && room.User2 == false)
            {
                room.User1 = true;
                return View(room);
            }
            else if (room.User1 == true && room.User2 == false)
            {
                room.User2 = true;
                return View(room);
            }
            else if (room.User1 == true && room.User2 == true)
            {
                return RedirectToAction("Index", new { id });
            }
            return NotFound();
        }

    }
}


