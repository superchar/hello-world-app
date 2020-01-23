
using AutoMapper;

namespace HelloWorld.V4.App_Start
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Read.Infrastructure.HelloWorld, Read.Domain.HelloWorldModel>()
                .ReverseMap();
                c.CreateMap<Read.Domain.HelloWorldModel, Models.HelloWorldViewModel>()
                .ReverseMap();
            });
        }
    }
}