using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace core7_mvc_mssql.Controllers;

public class LocateusController : Controller {
    public IActionResult Index() {
        return View();
    }
}