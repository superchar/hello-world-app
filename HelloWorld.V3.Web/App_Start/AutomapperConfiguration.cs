
namespace HelloWorld.V3.App_Start
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<HelloWorld.V3.Infrastructure.HelloWorld, Domain.HelloWorldModel>()
                .ReverseMap();
                c.CreateMap<HelloWorld.V3.Domain.HelloWorldModel, Models.HelloWorldViewModel>()
                .ReverseMap();
            });
        }
    }
}