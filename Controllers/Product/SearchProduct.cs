using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using core7_mvc_mssql.Services;
using core7_mvc_mssql.Data;
using core7_mvc_mssql.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Linq;


namespace core7_mvc_mssql.Controllers.Product;

public class SearchProduct : Controller {

    private readonly ILogger<SearchProduct> _logger;
    private readonly IProductService _productService;

    public SearchProduct(
        ILogger<SearchProduct> logger,
        IProductService productService)
    {
      _logger = logger;
      _productService = productService;
    }

    public IActionResult Index(ProductSearch key) {
        return View(key);
    }


    public IActionResult Search(ProductSearch key) {
        var products = from p in _productService.SearchProducts(key.Product_desc)
                    select p;

        return View("Search",products);
    }


}