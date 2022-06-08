﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int id)
        {
            _applicationDbContext.Rooms.ToList();
            var room = _applicationDbContext.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            //var messages = _repository.GetAll();
            return View(room);
        }
    }
}
