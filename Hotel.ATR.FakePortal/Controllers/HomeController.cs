using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hotel.ATR.FakePortal.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace Hotel.ATR.FakePortal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //TODO
    //private readonly IHttpContextAccessor HttpContext;

    public HomeController(ILogger<HomeController> logger)
     
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        //TODO
        //HttpContext.Session.SetString("iin", "03131313131");
        //var sessionData = HttpContext.Session.GetString("iin");

        CookieOptions options = new CookieOptions();
        options.Expires = DateTime.Now.AddSeconds(100);
        Response.Cookies.Append("iin", "03131313131",options);


        User user = new User();
        user.email = "nurbolatzursinbek@gmail.com";

        _logger.LogError("У пользователя {email}  врщникла ошибка {erorMessage}", user.email, "Ошибка пользователя");

        Stopwatch sw = new Stopwatch();
        _logger.LogInformation("обращение к сервису");
        sw.Start();
        Thread.Sleep(1000);
        //TODO
        sw.Stop();
        _logger.LogInformation("Сервис отработан за {ElapsedMilliseconds}", sw.ElapsedMilliseconds);
        _logger.LogError("Loggiong LogEror");
        _logger.LogWarning("Logging LogWarning");
        _logger.LogDebug("Logging LogDebug");



        return View();
    }

    [Authorize]
    public IActionResult Contact()
    {

        

        return View();
    }
    [HttpPost]
    public IActionResult login(string login, string password)
    {
        if (login == "admin" && password == "admin")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login)
            };
            var claimsIdentity = new ClaimsIdentity
                (claims, "Login");
            //TODO
            //HttpContext.SignIn
            //();

        }
        return View();

    }


    public IActionResult login()
    {
        return View();
    }
    public IActionResult Privacy()
    {

        return View();
    }
    public IActionResult About()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

