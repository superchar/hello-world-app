
using System.Data.Entity;

namespace HelloWorld.V2.Infrastructure
{
    public class HelloWorldDbContext : DbContext
    {
        public HelloWorldDbContext() : base("helloWorldDb")
        {
        }

        public DbSet<HelloWorld> HelloWorlds { get; set; }
    }
}
