
using System.Data.Entity;

namespace HelloWorld.V2.Infrastructure
{
    internal class HelloWorldDbContext : DbContext
    {
        public HelloWorldDbContext() : base("HelloWorldDb")
        {

        }

        public DbSet<HelloWorld> HelloWorlds { get; set; }
    }
}
