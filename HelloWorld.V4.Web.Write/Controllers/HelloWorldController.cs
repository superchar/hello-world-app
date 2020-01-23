using AutoMapper;
using HelloWorld.V4.Models;
using HelloWorld.V4.Write.Domain;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelloWorld.V4.Web.Write.Controllers
{
    [RoutePrefix("[controller]")]
    public class HelloWorldController : ApiController
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            this._helloWorldService = helloWorldService;
        }

        public async Task Post(HelloWorldViewModel model)
        {
            var mappedModel = Mapper.Map<HelloWorldModel>(model);

            await _helloWorldService.CreateAsync(mappedModel);
        }
    }
}
