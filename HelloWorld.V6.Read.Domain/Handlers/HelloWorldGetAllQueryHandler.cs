
using HelloWorld.V6.Read.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V6.Read.Domain.Handlers
{
    public class HelloWorldGetAllQueryHandler : IQueryHandler<HelloWorldGetAllQuery, List<HelloWorldQueryResult>>
    {
        private readonly IHelloWorldRepository _helloWorldRepository;

        public HelloWorldGetAllQueryHandler(IHelloWorldRepository helloWorldRepository)
        {
            this._helloWorldRepository = helloWorldRepository;
        }
        public async Task<List<HelloWorldQueryResult>> HandleAsync(HelloWorldGetAllQuery query)
        {
            var result = await _helloWorldRepository.GetAllAsync();
            return result;
        }

    }
}
