
using AutoMapper;
using HelloWorld.V4.Web.Read.SDK;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using HelloWorld.V4.Web.Models;

namespace HelloWorld.V4.Web.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IHelloWorldClient _helloWorldClient;

        public HelloWorldController(IHelloWorldClient helloWorldClient)
        {
            this._helloWorldClient = helloWorldClient;
        }


        public async Task<ActionResult> Index()
        {
            var models = await _helloWorldClient.GetAllAsync();

            var viewModels = Mapper.Map<List<HelloWorldViewModel>>(models);

            return View(viewModels);
        }
    }
}