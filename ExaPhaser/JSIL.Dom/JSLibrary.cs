using JSIL.Meta;

namespace JSIL.Dom
{
    public static class JSLibrary
    {
        [JSReplacement("alert($obj)")]
        public static void Alert(object obj)
        {
        }

        [JSReplacement("confirm($obj)")]
        public static void Confirm(object obj)
        {
        }
    }
}