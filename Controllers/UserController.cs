using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using core7_mvc_mssql.Data;
using core7_mvc_mssql.Services;
using core7_mvc_mssql.Models;

namespace core7_mvc_mssql;

public class UserController : Controller {

   private readonly UserManager<IdentityUser> _userManager;

   private readonly ILogger<UserController> _logger;

   private readonly IUserService _userService;

   public UserController(
    UserManager<IdentityUser> userManager,
    IUserService userService,
    ILogger<UserController> logger)
   {
     _userManager = userManager;
     _userService = userService;
     _logger = logger;
   }

    [HttpGet]
    public IActionResult Index() {
        ViewData["message"] = null;
        try {
            var useridno =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            var xuser = _userService.GetUserById(useridno);
            HttpContext.Session.SetString("USERPIC", xuser.Userpic);
            if(xuser is null) {
                return View();
            }
            return View(xuser);
        } catch(Exception) {
            return View();
        }
    }

   [HttpPost]
   public IActionResult Index(UserProfile usr, UploadfileModel model) {

    var userIdno =  User.FindFirstValue(ClaimTypes.NameIdentifier);
    usr.Userid = userIdno;
    if (model.Userpic is not null) {
        Console.WriteLine("picture not null...................");
        string ext= Path.GetExtension(model.Userpic.FileName);

        var folderName = Path.Combine("wwwroot", "images/users/");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        var newFilename =pathToSave + userIdno + ".jpg";

        using var image = SixLabors.ImageSharp.Image.Load(model.Userpic.OpenReadStream());
        image.Mutate(x => x.Resize(100, 100));
        image.Save(newFilename);

        string file = "/images/users/"+userIdno+".jpg";
        usr.Userpic = file;
        HttpContext.Session.SetString("USERPIC", file);
    }

    HttpContext.Session.SetString("FIRSTNAME", usr.Firstname);
        Console.WriteLine("picture is nulll.................");
          try {
            var uSer = _userService.GetUserById(userIdno);            
            uSer.Firstname = usr.Firstname;
            uSer.Lastname = usr.Lastname;
            int stat = _userService.addUser(uSer);            
            if (stat == 1) {
                ViewData["message"] = "User has been Updated.";
            } else if (stat == 2) {
                ViewData["message"] = "User has bee updated successfully.";
            } else {
                ViewData["message"] = null;
            }
            return View(usr);

          } catch(Exception) {

            int stat = _userService.addUser(usr);            
            if (stat == 1) {
                ViewData["message"] = "User has been Updated.";
            } else if (stat == 2) {
                ViewData["message"] = "User has been updated successfully.";
            } else {
                ViewData["message"] = null;
            }
            return View(usr);

          }

   }

}



    
