

using AutoMapper;
using HelloWorld.V4.Write.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HelloWorld.V4.Write.Infrastructure
{
    public class HelloWorldRepository : IHelloWorldRepository
    {
        public async Task<HelloWorldModel> CreateAsync(HelloWorldModel helloWorld)
        {
            using (var context = new HelloWorldDbContext())
            {
                context.HelloWorlds.Add(Mapper.Map<HelloWorld>(helloWorld));

                await context.SaveChangesAsync();

                return helloWorld;
            }
        }
    }
}
