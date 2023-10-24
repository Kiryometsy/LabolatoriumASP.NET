using Projekt.Models;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Controllers
{
    public class PhotoController : Controller
    {
        static readonly Dictionary<int, Photo> _photos = new Dictionary<int, Photo>();
        static int index = 1;
        public IActionResult Index()
        {
            return View(_photos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Photo model)
        {
            if(ModelState.IsValid)
            {
                model.Id = index++;
                _photos[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_photos[id]);
        }

        [HttpPost]
        public IActionResult Update(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photos[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_photos[id]);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_photos[id]);
        }

        [HttpPost]
        public IActionResult Delete(Photo model)
        {
            _photos.Remove(model.Id);
            return RedirectToAction("Index");
        }
    }
}
