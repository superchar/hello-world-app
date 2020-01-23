
namespace HelloWorld.V6.Write.Domain.Commands
{
    public class CreateHelloWorldCommand : Command
    {
        public string Name { get; set; }

        public string Message { get; set; }
    }
}
