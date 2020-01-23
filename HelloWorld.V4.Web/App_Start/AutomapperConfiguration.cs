
namespace HelloWorld.V4.Web
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<Read.SDK.HelloWorldDto, Models.HelloWorldViewModel>();
            });
        }
    }
}