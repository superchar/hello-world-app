

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V4.Write.Domain
{
    public interface IHelloWorldService
    {
        Task<HelloWorldModel> CreateAsync(HelloWorldModel helloWorld);
    }
}
