
using HelloWorld.V6.Read.Domain;
using HelloWorld.V6.Read.Domain.Queries;
using Raven.Client.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.V6.Read.Infrastructure
{
    public class RavenHelloWorldRepository : IHelloWorldRepository
    {
        public Task<List<HelloWorldQueryResult>> GetAllAsync()
        {
            using (IDocumentStore store = new DocumentStore
            {
                Urls = new[] { "http://localhost:9379" },
                Database = "HelloWorld",
                Conventions = { }
            })

            {
                store.Initialize();

                using (var session = store.OpenSession())
                {
                    return Task.FromResult(session.Query<HelloWorldQueryResult>(collectionName: "HelloWorldAddedEvents").ToList());
                }
            }
        }
    }
}
