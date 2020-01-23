
using AutoMapper;
using HelloWorld.V6.Read.Domain.Queries;
using HelloWorld.V6.Web.Read.Models;

namespace HelloWorld.V6.App_Start
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<HelloWorldQueryResult, HelloWorldViewModel>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            });
        }
    }
}