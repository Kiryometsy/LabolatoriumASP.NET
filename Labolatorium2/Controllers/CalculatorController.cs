using Microsoft.AspNetCore.Mvc;
using Labolatorium2.Models;
/***
 * 1. wysłanie żądania do formularza (potrzebna akcja w kontrolerze do formularza)
 * 2. wypełnienie formularza i submit
 * 3. wysłanie żądania z danymi formularza (potrzebna akcja odbierająca dane)
 * 4. obliczenie i zwrócenie widoku z wynikami
 * */ 
namespace Labolatorium2.Controllers
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
    }
}
