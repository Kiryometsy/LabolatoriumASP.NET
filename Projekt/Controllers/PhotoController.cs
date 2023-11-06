using Projekt.Models;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Controllers
{
    public class PhotoController : Controller
    {
        //static readonly Dictionary<int, Photo> _photos = new Dictionary<int, Photo>();
        //static int index = 1;
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        public IActionResult Index()
        {
            return View(_photoService.FindAll());
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
                _photoService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_photoService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_photoService.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_photoService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Photo model)
        {
            _photoService.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}
