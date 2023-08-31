using Microsoft.AspNetCore.Mvc;
using core7_mvc_mssql.Areas.Identity.Data;
using core7_mvc_mssql.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;   //FromSqlRaw
using System;
using System.Linq;
using Microsoft.Extensions.Options;

namespace core7_mvc_mssql.Services {

    public interface IProductService {
      int TotPage();
      IEnumerable<Product> GetProducts(int page);
      IEnumerable<Product> SearchProducts(string key);

    }

    public class ProductService : IProductService {

        private IdentityDataContext _context;


        public ProductService(IdentityDataContext context)
        {
            _context = context;
        }

       public int TotPage() {
            var perpage = 5;
            var totrecs = _context.Products.Count();
            int totpage = (int)Math.Ceiling((float)(totrecs) / perpage);
            return totpage;
        }

        public IEnumerable<Product> GetProducts(int page) {
            var perpage = 5;
            var offset = (page -1) * perpage;

            var products = _context.Products                                
                .OrderBy(b => b.Id)
                .Skip(offset)
                .Take(perpage)
                .ToList();
            return products;
        }

        public IEnumerable<Product> SearchProducts(string key) {
            if(key is not null) {
                var columnName = "prod_desc";
                var columnValue = new SqlParameter("columnValue", "%" + key + "%");
                var products = _context.Products.FromSqlRaw($"SELECT * FROM [Products] WHERE {columnName} LIKE @columnValue", columnValue).ToList();
                return products;
            } 
            return null;
        }

    }
}

