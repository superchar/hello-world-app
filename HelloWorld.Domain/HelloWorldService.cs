using AutoMapper;
using HelloWorld.V2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V2.Domain
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

            var created = await _repository.CreateAsync(Mapper.Map<Infrastructure.HelloWorld>(helloWorld));

            return Mapper.Map<HelloWorldModel>(created);
        }

        public async Task<IEnumerable<HelloWorldModel>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<HelloWorldModel>>(result);
        }
    }
}
