﻿

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.V3.Domain
{
    public interface IHelloWorldRepository
    {
        Task<List<HelloWorldModel>> GetAllAsync();

        Task<HelloWorldModel> CreateAsync(HelloWorldModel helloWorld);
    }
}
