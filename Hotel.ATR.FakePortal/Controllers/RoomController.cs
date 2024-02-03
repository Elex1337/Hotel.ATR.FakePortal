using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.ATR.FakePortal.Controllers
{
    public class RoomController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
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
    }
}

