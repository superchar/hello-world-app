

using HelloWorld.V5.Write.Infrastructure.Events;
using System.Threading.Tasks;

namespace HelloWorld.V5.Write.Infrastructure.Handlers
{
    public interface IEventHandler<T> where T : Event
    {
        Task HandleAsync(T targetEvent);
    }
}
