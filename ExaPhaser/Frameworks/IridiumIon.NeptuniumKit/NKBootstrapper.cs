using JSIL;
using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit
{
    public static class NKBootstrapper
    {
        public static void StartApplication(NKApplication app, string targetElementSelector)
        {
            //Verify that we are running on JSIL
            if (Verbatim.Expression("0") == null)
            {
                throw new RequiresJSILRuntimeException();
            }
            //TODO: Initialize DOM host object with jQuery
            var targetElement = new JQElement(JQuery.FromSelector(targetElementSelector).DomRepresentation);
            app.HostElement = targetElement;
            app.Create();
        }
    }
}