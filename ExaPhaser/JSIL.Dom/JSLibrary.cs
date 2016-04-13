using JSIL.Meta;

namespace JSIL.Dom
{
    public static class JSLibrary
    {
        #region Public Methods

        [JSReplacement("alert($obj)")]
        public static void Alert(object obj)
        {
        }

        [JSReplacement("confirm($obj)")]
        public static void Confirm(object obj)
        {
        }

        [JSReplacement("Array.prototype.slice.call($obj)")]
        public static object[] ObjectToArray(object obj)
        {
            throw new RequiresJSILRuntimeException();
        }

        #endregion Public Methods
    }
}