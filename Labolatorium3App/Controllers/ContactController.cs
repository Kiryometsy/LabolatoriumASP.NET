using Labolatorium3App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3App.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid)
            {
                // zapisz obiekt do bazy/kolekcji albo wykonaj operację
            }
            return View();
        }
    }
}
