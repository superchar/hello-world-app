

using System.Collections.Generic;

namespace HelloWorld.V6.Read.Domain.Queries
{
    public class HelloWorldGetAllQuery : Query<List<HelloWorldQueryResult>>
    {
        public static readonly HelloWorldGetAllQuery Instance = new HelloWorldGetAllQuery();
        private HelloWorldGetAllQuery()
        {

        }
    }
}
