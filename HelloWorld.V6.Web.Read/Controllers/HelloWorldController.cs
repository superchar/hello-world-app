using AutoMapper;
using HelloWorld.V6.Read.Domain.Handlers;
using HelloWorld.V6.Read.Domain.Queries;
using HelloWorld.V6.Web.Read.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelloWorld.V6.Web.Read.Controllers
{
    [RoutePrefix("[controller]")]
    public class HelloWorldController : ApiController
    {
        private readonly IQueryHandler<HelloWorldGetAllQuery, List<HelloWorldQueryResult>> _handler;

        public HelloWorldController(IQueryHandler<HelloWorldGetAllQuery, List<HelloWorldQueryResult>> handler)
        {
            this._handler = handler;
        }

        public async Task<IEnumerable<HelloWorldViewModel>> Get()
        {
            var result = await _handler.HandleAsync(HelloWorldGetAllQuery.Instance);

            return Mapper.Map<IEnumerable<HelloWorldViewModel>>(result);
        }
    }
}
