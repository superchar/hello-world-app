﻿
using AutoMapper;
using HelloWorld.V2.Domain;
using HelloWorld_V2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelloWorld_V2.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IHelloWorldService _service;

        public HelloWorldController(IHelloWorldService service)
        {
            this._service = service;
        }
        public async Task<ActionResult> Index()
        {
            var models = await _service.GetAllAsync();
            var viewModels = Mapper.Map<List<HelloWorldViewModel>>(models);
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View(new HelloWorldViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(HelloWorldViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _service.CreateAsync(Mapper.Map<HelloWorldModel>(model));
            return RedirectToAction(nameof(HelloWorldController.Index));
        }
    }
}