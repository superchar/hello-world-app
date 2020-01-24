
using System.Data.Entity;

namespace HelloWorld.V3.Infrastructure
{
    internal class HelloWorldDbContext : DbContext
    {
        public HelloWorldDbContext() : base("helloWorldDb")
        {

        }
        public DbSet<HelloWorld> HelloWorlds { get; set; }
    }
}
