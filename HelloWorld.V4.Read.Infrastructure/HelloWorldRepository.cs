

using AutoMapper;
using HelloWorld.V4.Read.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HelloWorld.V4.Read.Infrastructure
{
    public class HelloWorldRepository : IHelloWorldRepository
    {

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
