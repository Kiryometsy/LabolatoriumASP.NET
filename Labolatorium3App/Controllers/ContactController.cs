﻿using Labolatorium3App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3App.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.Organizations = _contactService.FindAllOrganizations()
                .Select(oe => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = oe.Name,
                    Value = oe.Id.ToString()
                }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid)
            {
                _contactService.Add(model);
                // model.Id = index++;
                // _contacts[model.Id] = model;
                return RedirectToAction("Index");
            } else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.Delete(model.Id);
            return RedirectToAction("Index");
        }


    }
}
