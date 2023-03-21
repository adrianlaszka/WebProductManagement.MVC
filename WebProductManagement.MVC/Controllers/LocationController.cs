using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebProductManagement.MVC.Data;
using DataAccessLayer.DataTable;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebProductManagement.MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly SolarPanelContext _panelContext;

        //Constructor
        public LocationController(SolarPanelContext context)
        {
            _panelContext = context;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetById(int id)
        {
            var location = await _panelContext.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Create(Location location)
        {
            _panelContext.Locations.Add(location);
            await _panelContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = location.ID }, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Location location)
        {
            if (id != location.ID)
            {
                return BadRequest();
            }

            _panelContext.Entry(location).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _panelContext.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (_panelContext.Locations.Find(id) == null)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _panelContext.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            _panelContext.Locations.Remove(location);
            await _panelContext.SaveChangesAsync();

            return NoContent();
        }

        //rekeszek, amik az adott alkatrészt tartalmazzák és van benne hely
        [HttpGet("AvailableFor/{alkatreszNev}")]
        public IActionResult GetAvailableBoxesForProducts(string _productName)
        {
            var availableBoxes = _panelContext.Products
                .Where(r => r.ProductName == _productName && r.InStock < r.MaxPerCell)
                .ToList();

            return Ok(availableBoxes);
        }

        //üres rekeszek meghatározásához
        public IActionResult GetEmptyBoxes()
        {
            var emptyBoxes = _panelContext.Locations
                .Where(r => r.ProductID == 0)
                .ToList();

            return Ok(emptyBoxes);
        }
    }
}
