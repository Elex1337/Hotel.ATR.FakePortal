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
        private readonly ILogger<RoomController> _logger;

        private IWebHostEnvironment webHost;

        public RoomController(IWebHostEnvironment webHost, ILogger<RoomController> _logger) 
        {
            this.webHost = webHost;
            this._logger = _logger;
            }
        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            _logger.LogInformation("Logging LogInforamtion");
            _logger.LogError("Loggiong LogEror");
            _logger.LogWarning("Logging LogWarning");
            _logger.LogDebug("Logging LogDebug");
            ViewBag.Id = id;
            TempData["id"] = id;
            return View();
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

