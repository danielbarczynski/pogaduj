using Microsoft.AspNetCore.Mvc;
using pogaduj.Repository;

namespace pogaduj.Controllers
{
    public class ChatController : Controller
    {
        private readonly IMessages _repository;
        public ChatController(IMessages repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var messages = _repository.GetAll();
            return View(messages);
        }

    }
}
