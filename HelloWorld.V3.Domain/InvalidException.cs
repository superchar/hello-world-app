
using System;

namespace HelloWorld.V3.Domain
{
    public class InvalidException : Exception
    {
        public InvalidException(string entityName) : base($"{entityName} is not valid")
        {

        }

    }
}
