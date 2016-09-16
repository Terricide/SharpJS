using System;

namespace JSIL
{
    public class RequiresJSILRuntimeException : Exception
    {
        public RequiresJSILRuntimeException() : base("This method is a stub! It must be run in the JSIL runtime.")
        {
        }
    }
}