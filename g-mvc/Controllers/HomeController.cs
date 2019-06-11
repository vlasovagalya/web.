using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using g_mvc.Models;
using g_mvc.Services;

namespace g_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoomService roomService;
        public HomeController(RoomService roomService)
        {
            this.roomService = roomService;
        }
        public IActionResult Index()
        {
            ViewData["rooms"] = roomService.Get();
            return View();
        }
        
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Upload(string title, string city, int roomCount, int square, string ownerFullName, string ownerPhone)
        {
            var room = new Room()
            {
                Title = title,
                City = city,
                RoomCount = roomCount,
                Square = square,
                OwnerFullName = ownerFullName,
                OwnerPhone = ownerPhone
                
            };
            roomService.Create(room);
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}