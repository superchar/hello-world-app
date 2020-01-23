
using AutoMapper;

namespace HelloWorld.V4.App_Start
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Write.Infrastructure.HelloWorld, Write.Domain.HelloWorldModel>()
                .ReverseMap();
                c.CreateMap<Write.Domain.HelloWorldModel, Models.HelloWorldViewModel>()
                .ReverseMap();
            });
        }
    }
}