using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.ATR.FakePortal.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.ATR.FakePortal.Controllers
{
    public class RoomController : Controller
    {
        private IWebHostEnvironment webHost;

        public RoomController(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
            }
        // GET: /<controller>/
        public IActionResult Index(int page, int counter)
        {
            var user = new User() { email = "Ok@gmail.com", name = "hello" };
            ViewBag.User = user;
            ViewData["user"] = user;
            TempData["user"] = user;
            return View(user);
        }
       
       public IActionResult RoomDetails()
        {
            return View();
        }
        public IActionResult RoomList()
        {
            return View();
        }
        // string email User user
        [HttpPost]
        public IActionResult SubscribeNewsLetter(IFormFile userfile)
        {
            var data = Request.Form["email"];
            string path = Path.Combine(webHost.WebRootPath,userfile.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                userfile.CopyTo(stream);
            }
            return View();
            }
        }

}

