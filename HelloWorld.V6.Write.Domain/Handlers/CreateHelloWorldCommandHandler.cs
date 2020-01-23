
using HelloWorld.V4.Write.Domain;
using HelloWorld.V6.Write.Domain.Commands;
using System.Threading.Tasks;

namespace HelloWorld.V6.Write.Domain.Handlers
{
    public class CreateHelloWorldCommandHandler : ICommandHandler<CreateHelloWorldCommand>
    {
        private readonly IHelloWorldRepository _helloWorldRepository;

        public CreateHelloWorldCommandHandler(IHelloWorldRepository helloWorldRepository)
        {
            this._helloWorldRepository = helloWorldRepository;
        }
        public async Task HandleAsync(CreateHelloWorldCommand command)
        {
            var model = new HelloWorldModel { Message = command.Message, Name = command.Name };

            await _helloWorldRepository.CreateAsync(model);
        }
    }
}
