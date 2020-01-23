

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V2.Domain
{
    public interface IHelloWorldService
    {
        Task<IEnumerable<HelloWorldModel>> GetAllAsync();

        Task<HelloWorldModel> CreateAsync(HelloWorldModel helloWorld);
    }
}
