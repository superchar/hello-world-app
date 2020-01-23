
namespace HelloWorld_V2.App_Start
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<HelloWorld.V2.Infrastructure.HelloWorld, HelloWorld.V2.Domain.HelloWorldModel>()
                .ReverseMap();
                c.CreateMap<HelloWorld.V2.Domain.HelloWorldModel, HelloWorld_V2.Models.HelloWorldViewModel>()
                .ReverseMap();
            });
        }
    }
}