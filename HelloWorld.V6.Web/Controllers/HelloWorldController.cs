
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


        public HelloWorldController(IHelloWorldClient helloWorldReadClient)
        {
            this._helloWorldReadClient = helloWorldReadClient;
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

    }
}