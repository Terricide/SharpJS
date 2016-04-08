using System;

namespace JSIL.Dom
{
    internal class RequiresJSILRuntimeException : Exception
    {
        public RequiresJSILRuntimeException() : base("This method must be run in the JSIL runtime.")
        {
        }
    }
}