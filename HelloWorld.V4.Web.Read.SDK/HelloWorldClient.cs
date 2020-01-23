

using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

using System.Threading.Tasks;

namespace HelloWorld.V4.Web.Read.SDK
{
    class HelloWorldClient : IHelloWorldClient
    {
        private static readonly string Url = ConfigurationManager.AppSettings["ReadServiceUrl"];
        public async Task<IEnumerable<HelloWorldDto>> GetAllAsync()
        {
            using(var client = new HttpClient())
            {
                var result = await client.GetAsync(Url);
                var dtoes = await result.Content.ReadAsAsync<IEnumerable<HelloWorldDto>>();
                return dtoes;
            }
        }
    }
}
