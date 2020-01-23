using EventStore.ClientAPI;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HelloWorld.V6.ProjectionManager.Console.Read
{
    class Program
    {
        private const string StreamName = "HelloWorldApp";

        private static Random Random = new Random();

        static async Task Main(string[] args)
        {
            var conn = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"), StreamName);
            await conn.ConnectAsync();


            using (IDocumentStore store = new DocumentStore
            {
                Urls = new[] { "http://localhost:9379" },
                Database = "HelloWorld",
                Conventions = { }
            })

            {
                store.Initialize();

                System.Console.WriteLine("Connected. Press any key to disconnect");

                 using (conn.SubscribeToStreamAsync(StreamName, false, (s, e) =>
                 {
                     var helloWorldEvent = Utf8Json.JsonSerializer.Deserialize<HelloWorldAddedEvent>(e.Event.Data);

                     AppendPrefixAndAddId(helloWorldEvent);

                     SaveToRaven(helloWorldEvent, store);
                 }))
                {
                    System.Console.ReadKey();
                }
            }
        }

        private static void AppendPrefixAndAddId(HelloWorldAddedEvent helloWorldAddedEvent)
        {
            var prefix = Random.Next(0, 2) == 0 ? "Mr" : "Mrs";
            helloWorldAddedEvent.Name = $"{prefix} {helloWorldAddedEvent.Name}";
            helloWorldAddedEvent.Id = Guid.NewGuid().ToString();
        }

        private static void SaveToRaven(HelloWorldAddedEvent helloWorldAddedEvent, IDocumentStore documentStore)
        {
            using (IDocumentSession session = documentStore.OpenSession())
            {

                session.Store(helloWorldAddedEvent);


                session.SaveChanges();

            }
        }

    }

    public class HelloWorldAddedEvent
    {
        public string Message { get; set; }

        public string Name { get; set; }

        [IgnoreDataMember]
        public string Id { get; set; }

    }
}
