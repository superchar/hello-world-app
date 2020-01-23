

using AutoMapper;
using HelloWorld.V4.Write.Domain;
using HelloWorld.V5.Write.Infrastructure.Events;
using HelloWorld.V5.Write.Infrastructure.Handlers;
using System.Threading.Tasks;

namespace HelloWorld.V5.Write.Infrastructure
{
    public class HelloWorldEventRepository : IHelloWorldRepository
    {
        private readonly IEventHandler<HelloWorldAddedEvent> _eventHandler;

        public HelloWorldEventRepository(IEventHandler<HelloWorldAddedEvent> eventHandler)
        {
            this._eventHandler = eventHandler;
        }
        public async Task<HelloWorldModel> CreateAsync(HelloWorldModel helloWorld)
        {
            await _eventHandler.HandleAsync(Mapper.Map<HelloWorldAddedEvent>(helloWorld));
            return helloWorld;
        }
    }
}
