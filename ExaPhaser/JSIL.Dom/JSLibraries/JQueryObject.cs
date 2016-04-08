using JSIL.Meta;

namespace JSIL.Dom.JSLibraries
{
    public class JQueryObject
    {
        protected object _jqobject;

        internal JQueryObject(object handle)
        {
            _jqobject = handle;
        }

        [JSReplacement("$_jqobject.css($name,$value)")]
        public void CSS(string name, string value)
        {
        }

        [JSReplacement("$_jqobject.css($name)")]
        public string CSS(string name)
        {
            throw new RequiresJSILRuntimeException();
        }
    }
}