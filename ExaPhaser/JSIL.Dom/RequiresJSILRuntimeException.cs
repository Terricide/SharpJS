using System;

namespace JSIL
{
    public class RequiresJSILRuntimeException : Exception
    {
        public RequiresJSILRuntimeException() : base("This method must be run in the JSIL runtime.")
        {
        }
    }
}