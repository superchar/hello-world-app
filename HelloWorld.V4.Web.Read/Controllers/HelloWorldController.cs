using AutoMapper;
using HelloWorld.V4.Models;
using HelloWorld.V4.Read.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelloWorld.V4.Web.Read.Controllers
{
    [RoutePrefix("[controller]")]
    public class HelloWorldController : ApiController
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            this._helloWorldService = helloWorldService;
        }

        public async Task<IEnumerable<HelloWorldViewModel>> Get()
        {
            var result = await _helloWorldService.GetAllAsync();

            return Mapper.Map<IEnumerable<HelloWorldViewModel>>(result);
        }
    }
}
