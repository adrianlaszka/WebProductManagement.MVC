using Microsoft.AspNetCore.Mvc;
using SolutionLogic.Interface;
using System.Threading.Tasks;

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

}
}