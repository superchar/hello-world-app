

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V4.Read.Domain
{
    public interface IHelloWorldService
    {
        Task<IEnumerable<HelloWorldModel>> GetAllAsync();
    }
}
