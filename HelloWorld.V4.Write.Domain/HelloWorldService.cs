using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V4.Write.Domain
{
    public class HelloWorldService : IHelloWorldService
    {
        private static readonly HashSet<string> ValidHelloWorlds = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "hello,world",
            "hello world",
            "hello world!",
            "hello,world!"
        };

        private readonly IHelloWorldRepository _repository;

        public HelloWorldService(IHelloWorldRepository repository)
        {
            this._repository = repository;
        }
        public async Task<HelloWorldModel> CreateAsync(HelloWorldModel helloWorld)
        {
            if (!ValidHelloWorlds.Contains(helloWorld?.Message))
            {
                throw new InvalidException(nameof(HelloWorldModel));
            }

            return await _repository.CreateAsync(helloWorld);
        }
    }
}
