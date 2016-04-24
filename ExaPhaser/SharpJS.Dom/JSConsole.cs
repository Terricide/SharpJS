using JSIL.Meta;

namespace SharpJS.Dom
{
    public static class JSConsole
    {
        [JSReplacement("console.log($args)")]
        public static void Log(params object[] args)
        {
        }
    }
}