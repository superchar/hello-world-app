using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V4.Read.Domain
{
    public class HelloWorldService : IHelloWorldService
    {

        private readonly IHelloWorldRepository _repository;

        public HelloWorldService(IHelloWorldRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<HelloWorldModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
