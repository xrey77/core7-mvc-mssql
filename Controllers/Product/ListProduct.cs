using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using core7_mvc_mssql.Services;
using core7_mvc_mssql.Data;
using core7_mvc_mssql.Models;

namespace core7_mvc_mssql.Controllers.Product;

public class ListProduct : Controller {
    private readonly ILogger<ListProduct> _logger;
    private readonly IProductService _productService;

    public ListProduct(
        ILogger<ListProduct> logger,
        IProductService productService)
    {
      _logger = logger;
      _productService = productService;
    }

    [HttpGet("/getproducts/{pg}")]
    public IActionResult Index(int pg) {
        var products = from p in _productService.GetProducts(pg)
                    select p;

        var totPage = _productService.TotPage();
        ViewData["totpage"] = totPage;        
        ViewData["page"] = pg;
        TempData["pg"] = pg;
        return View("Index",products);
    }

    public IActionResult Nextpage() {
            var totPage = _productService.TotPage();

            var pno =(int) TempData["pg"] + 1;

            if (pno > totPage) {
                var products = from p in _productService.GetProducts(totPage)
                            select p;
                TempData["totPg"] = totPage;
                ViewData["totpage"] = totPage;        
                ViewData["page"] = totPage;
                TempData["pg"] = totPage;
                return View("Index", products);

            } else {

                var products = from p in _productService.GetProducts(pno)
                            select p;

                TempData["totPg"] = totPage;
                ViewData["totpage"] = totPage;        
                ViewData["page"] = pno;
                TempData["pg"] = pno;
                return View("Index", products);
            }
    }

    public IActionResult FirstPage() {
        ViewData["page"] = 1;
        TempData["pg"]=1;
        var products = from p in _productService.GetProducts(1)
                    select p;

        var totPage = _productService.TotPage();
        ViewData["totpage"] = totPage;        

        return View("Index", products);
    }

    public IActionResult PrevPage() {
        try {
            var pno =(int) TempData["pg"] - 1;
            TempData["pg"] = pno;
            var products = from p in _productService.GetProducts(pno)
                        select p;

            var totPage = _productService.TotPage();
            ViewData["totpage"] = totPage;        
            ViewData["page"] = pno;
            TempData["pg"] = pno;
            return View("Index", products);

        } catch(Exception) {

            TempData["pg"] = 1;
            var products = from p in _productService.GetProducts(1)
                        select p;

            var totPage = _productService.TotPage();
            ViewData["totpage"] = totPage;        
            ViewData["page"] = 1;
            return View("Index", products);
        }
    }

    public IActionResult LastPage() {
        var totPage = _productService.TotPage();
        ViewData["page"] = totPage;
        TempData["pg"] = totPage;
        var products = from p in _productService.GetProducts(totPage)
                    select p;

        ViewData["totpage"] = totPage;        
        return View("Index", products);
    }
}
