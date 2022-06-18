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

        public IActionResult Index(int id, RoomModel roomModel)
        {
            id++;
            _applicationDbContext.Rooms.ToList();
            var room = _applicationDbContext.Rooms.Find(id);

            if(room == null)
            {
                return NotFound();
            }    

            if (room.User1 == 0 && room.User2 == 0)
            {
                room.User1 = 1;
            }
            else if (room.User1 == 1 && room.User2 == 0)
            {
                room.User2 = 1;
            }
            else if (room.User1 == 1 && room.User2 == 1)
            {
                return RedirectToAction("Index", new { id = id, roomModel = roomModel });
            }

            _applicationDbContext.Rooms.Update(roomModel);
            _applicationDbContext.Rooms.Remove(roomModel);
            _applicationDbContext.SaveChanges();
            return View(room);
        }

        public IActionResult Leave(RoomModel roomModel2, int id)
        {
            id++;
            _applicationDbContext.Rooms.ToList();
            var roomModel = _applicationDbContext.Rooms.Find(id);

            if (roomModel == null)
            {
                return NotFound();
            }

            if (roomModel.User1 == 1 && roomModel.User2 == 0)
            {
                roomModel.User1 = 0;           
            }
            else if (roomModel.User1 == 0 && roomModel.User2 == 1)
            {
                roomModel.User2 = 0;
            }
            else if (roomModel.User1 == 1 && roomModel.User2 == 1)
            {
                roomModel.User1 = 0;
            }
            
            _applicationDbContext.Rooms.Update(roomModel2);
            _applicationDbContext.Rooms.Remove(roomModel2);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}


