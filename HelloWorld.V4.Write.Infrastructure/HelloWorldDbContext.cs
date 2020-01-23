
using System.Data.Entity;

namespace HelloWorld.V4.Write.Infrastructure
{
    internal class HelloWorldDbContext : DbContext
    {
        public HelloWorldDbContext() : base("helloWorldDb")
        {

        }

        public DbSet<HelloWorld> HelloWorlds { get; set; }
    }
}
