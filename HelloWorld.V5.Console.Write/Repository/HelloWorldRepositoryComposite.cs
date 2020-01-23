

using HelloWorld.V4.Write.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.V5.Console.Write.Repository
{
    class HelloWorldRepositoryComposite : IHelloWorldRepositoryComposite
    {
        private IHelloWorldRepository[] _repositories;

        public HelloWorldRepositoryComposite(IHelloWorldRepository[] repositories)
        {
            this._repositories = repositories;
        }

        public async Task<HelloWorldModel> CreateAsync(HelloWorldModel helloWorld)
        {
            var tasks = _repositories.Select(r=> r.CreateAsync(helloWorld));
            await Task.WhenAll(tasks);
            return helloWorld;
        }
    }
}
