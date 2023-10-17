using Microsoft.AspNetCore.Mvc;

namespace Labolatorium2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Welcome([FromForm] BirthModel model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
    }
}
