using Microsoft.AspNetCore.Mvc;

namespace WebProductManagement.MVC.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Frontendről érkezik a kiválasztott alkatrész.
        //Ki kellene keresni minden olyan rekeszt, ami az adott alkatrészt tartalmazza és még van benne hely.
        //Továbbá kellene minden üres rekesz.
        //Ezeket jeleníteném meg, és akkor az adott alkatrészt el tudja helyezni valamely rekeszbe.
        public ActionResult ListLocations(int id, string productName, int inStock, int maxPerCell, decimal price)
        {
            ViewBag.id = id;
            ViewBag.productName = productName;
            ViewBag.inStock = inStock;
            ViewBag.maxPerCell = maxPerCell;
            ViewBag.price = price;
            //ViewBag.price = locations;
            return View();
            
        }
    }
}
