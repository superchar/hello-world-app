

using HelloWorld.V6.Write.Domain.Commands;
using System.Threading.Tasks;

namespace HelloWorld.V6.Write.Domain.Handlers
{
    public interface ICommandHandler<T> where T : Command
    {
        Task HandleAsync(T command);
    }
}
