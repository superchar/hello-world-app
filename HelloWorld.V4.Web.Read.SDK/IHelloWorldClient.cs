

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V4.Web.Read.SDK
{
    public interface IHelloWorldClient
    {
        Task<IEnumerable<HelloWorldDto>> GetAllAsync();
    }
}
