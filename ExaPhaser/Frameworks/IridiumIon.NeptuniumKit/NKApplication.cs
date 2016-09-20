using JSIL;

namespace IridiumIon.NeptuniumKit
{
    public class NKApplication
    {
        public NKApplication()
        {
            if (Verbatim.Expression("0") == null)
            {
                throw new RequiresJSILRuntimeException();
            }
        }
    }
}