using JSIL.Meta;

namespace SharpJS.Dom
{
    public static class JSConsole
    {
        [JSReplacement("console.log($args)")]
        public static void Log(params object[] args)
        {
        }

        [JSReplacement("console.error($args)")]
        public static void Error(params object[] args)
        {
        }

        [JSReplacement("console.assert($args)")]
        public static void Debug(params object[] args)
        {
        }
    }
}