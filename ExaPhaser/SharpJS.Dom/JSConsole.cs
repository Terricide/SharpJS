using JSIL.Meta;

namespace SharpJS.Dom
{
    public static class JSConsole
    {
        [JSReplacement("console.log($obj)")]
        public static void Log(object obj)
        {
        }
    }
}