using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using core7_mvc_mssql.Models;
using Microsoft.AspNetCore.Http;
using core7_mvc_mssql.Services;

namespace core7_mvc_mssql.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(
        IUserService userService,
        ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager)
    {
        _userService = userService;
        _userManager = userManager;
        _logger = logger;
    }
    public IActionResult Index()
    {
        try {
            // GET LOGGED IN USER ID
            var useridno =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            // GET USER PICTURE FROM USERPROFILE
            var xuser = _userService.GetUserById(useridno);
            // STORE USER PICTURE IN SESSION 
            HttpContext.Session.SetString("USERPIC", xuser.Userpic);
            HttpContext.Session.SetString("FIRSTNAME", xuser.Firstname);

        } catch(Exception) {}

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
