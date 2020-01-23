
using AutoMapper;
using HelloWorld.V4.Web.Read.SDK;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using HelloWorld.V6.Web.Models;

namespace HelloWorld.V6.Web.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IHelloWorldClient _helloWorldReadClient;

        private readonly V4.Web.Write.SDK.IHelloWorldClient _helloWorldWriteClient;


        public HelloWorldController(IHelloWorldClient helloWorldReadClient, V4.Web.Write.SDK.IHelloWorldClient helloWorldWriteClient)
        {
            this._helloWorldReadClient = helloWorldReadClient;
            this._helloWorldWriteClient = helloWorldWriteClient;
        }


        public async Task<ActionResult> Index()
        {
            var models = await _helloWorldReadClient.GetAllAsync();

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
            await _helloWorldWriteClient.CreateAsync(Mapper.Map<V4.Web.Write.SDK.HelloWorldDto>(model));

            return RedirectToAction(nameof(HelloWorldController.Index));
        }
    }
}