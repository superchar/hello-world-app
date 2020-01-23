

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HelloWorld.V2.Infrastructure
{
    public class HelloWorldRepository : IHelloWorldRepository
    {
        public async Task<HelloWorld> CreateAsync(HelloWorld helloWorld)
        {
            using(var context = new HelloWorldDbContext())
            {
                context.HelloWorlds.Add(helloWorld);

                await context.SaveChangesAsync();

                return helloWorld;
            }
        }

        public async Task<List<HelloWorld>> GetAllAsync()
        {
            using (var context = new HelloWorldDbContext())
            {
                var result = await context.HelloWorlds.ToListAsync();
                return result;
            }
        }
    }
}
