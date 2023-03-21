using DataAccessLayer.DataTable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionLogic.Interface;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebProductManagement.MVC.Data;
using System.Data;

namespace WebProductManagement.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductReposity _repo; // I call the interface to get access to the GetAllProducts implementation
        private readonly SolarPanelContext _panelContext;

        public ProductController(IProductReposity repo)// Instanace of the intertace 
        {
            _repo = repo;
        }

        public ProductController(SolarPanelContext context)
        {
            _panelContext = context;
        }

        public async Task<IActionResult> Index()
        {
            //var productList = await _repo.GetAllProducts();  // Call the main logic GetAllProducts
            var productList = await _panelContext.Products.ToListAsync();
            return View(productList);
        }

        //Alkatrész hozzáadása nézet megjelenítése
        public ActionResult CreateProduct()
        {
            return View();
        }

        //Alkatrész neve, ára, max elhelyezhető mennyisége jön a frontend-ről
        //Ezt az új alkatrész objektumot kell eltárolni az adatbázisban
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

        //A kiválasztott alkatrész érkezik ide, az alkatrészek listázása nézetről.
        //Aztán ezek az adatok mennek tovább az alkatrész módosítása nézetre, ahol lehet módosítani bármely paraméterét.
        [HttpPost]
        public ActionResult UpdateProduct(int id, string productName, int inStock, int maxPerCell, decimal price)
        {
            ViewBag.id = id;
            ViewBag.productName = productName;
            ViewBag.inStock = inStock;
            ViewBag.maxPerCell = maxPerCell;
            ViewBag.price = price;
            return View();
            //return Content(id.ToString() + " " + productName + inStock + " " + maxPerCell + " " + price);
        }

        //Frontendről jönnek a a módosított alkatrész adatai.
        //Ezt a módosított objektumot kell frissíteni az adatbázisba.
        [HttpPost]
        public async Task<IActionResult> UpdateProductParameters(int _id, Product _prod, string _productName, decimal price, int maxPerCell)
        {
            if (_id != _prod.Id)
            {
                return BadRequest();
            }

            _panelContext.Entry(_prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                var prod = _panelContext.Products.Where(p => p.Id == _id).FirstOrDefault();

                if (prod is Product)
                {
                    prod.ProductName = _productName;
                    prod.Price = price;
                    prod.MaxPerCell = maxPerCell;
                }
                await _panelContext.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (_panelContext.Products.Find(_id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
    }
}