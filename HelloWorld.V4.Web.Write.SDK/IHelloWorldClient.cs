

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V4.Web.Write.SDK
{
    public interface IHelloWorldClient
    {
        Task<HelloWorldDto> CreateAsync(HelloWorldDto helloWorldDto);
    }
}
