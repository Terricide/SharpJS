using JSIL.Meta;

namespace System.Diagnostics
{
    public static class Debug
    {
        [JSReplacement("if (!$condition) { throw 'Assertion failed'; }"), Conditional("DEBUG")]
        public static void Assert(bool condition)
        {
        }

        [JSReplacement("if (!$condition) { throw ('Assertion failed: ' + $message); }"), Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
        }

        [JSReplacement("console.log($value)"), Conditional("DEBUG")]
        public static void WriteLine(object value)
        {
        }

        [JSReplacement("console.log($message)"), Conditional("DEBUG")]
        public static void WriteLine(string message)
        {
        }

        [Conditional("DEBUG")]
        public static void WriteLine(string format, params object[] args)
        {
            Debug.WriteLine(string.Format(format, args));
        }

        [JSReplacement("if ($condition) { console.log($message); }"), Conditional("DEBUG")]
        public static void WriteLineIf(bool condition, string message)
        {
        }
    }
}