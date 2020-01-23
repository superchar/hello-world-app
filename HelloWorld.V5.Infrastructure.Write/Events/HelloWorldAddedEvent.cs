
namespace HelloWorld.V5.Write.Infrastructure.Events
{
    public class HelloWorldAddedEvent : Event
    {
        public string Message { get; set; }

        public string Name { get; set; }
    }
}
