

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V2.Infrastructure
{
    public interface IHelloWorldRepository
    {
        Task<List<HelloWorld>> GetAllAsync();

        Task<HelloWorld> CreateAsync(HelloWorld helloWorld);
    }
}
