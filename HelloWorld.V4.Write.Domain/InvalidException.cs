
using System;

namespace HelloWorld.V4.Write.Domain
{
    public class InvalidException : Exception
    {
        public InvalidException(string entityName) : base($"{entityName} is not valid")
        {

        }

    }
}
