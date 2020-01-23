
using HelloWorld.V6.Read.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V6.Read.Domain
{
    public interface IHelloWorldRepository
    {
        Task<List<HelloWorldQueryResult>> GetAllAsync();
    }
}
