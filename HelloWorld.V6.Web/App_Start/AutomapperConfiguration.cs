
using AutoMapper;

namespace HelloWorld.V6.Web
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<V4.Web.Read.SDK.HelloWorldDto, Models.HelloWorldViewModel>().ReverseMap();

            });
        }
    }
}