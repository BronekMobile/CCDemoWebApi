using System;
using System.Runtime.Serialization;

namespace CCDemoAPI.Exceptions
{
    internal class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

      
    }
}