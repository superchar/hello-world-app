

using AutoMapper;
using HelloWorld.V3.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HelloWorld.V3.Infrastructure
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

        public async Task<List<HelloWorldModel>> GetAllAsync()
        {
            using (var context = new HelloWorldDbContext())
            {
                var result = await context.HelloWorlds.ToListAsync();

                return Mapper.Map<List<HelloWorldModel>>(result);
            }
        }
    }
}
