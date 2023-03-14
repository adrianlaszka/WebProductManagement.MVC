using DataAccessLayer.DataTable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionLogic.Interface;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebProductManagement.MVC.Controllers
{
public class ProductController : Controller
{
        private readonly IProductReposity _repo; // I call the interface to get access to the GetAllProducts implementation
        public ProductController(IProductReposity repo)// Instanace of the intertace 
        {
            _repo = repo;
        }
      public async  Task<IActionResult> Index()
      {
            var productList = await _repo.GetAllProducts();  // Call the main logic GetAllProducts
            return View(productList);
      }

      public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(string productName, decimal price, int maxPerCell)
        {
            Product product = new Product();
            product.ProductName = productName;
            product.Price = price;
            product.MaxPerCell = maxPerCell;
            return View();
            //return Content(productName);
        }


    }
}