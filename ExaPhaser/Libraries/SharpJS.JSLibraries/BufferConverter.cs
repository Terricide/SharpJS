using JSIL;
using JSIL.Meta;

namespace SharpJS.JSLibraries
{
    public class BufferConverter
    {
        [JSReplacement(@"String.fromCharCode.apply(null, new Uint8Array($arrayBuffer))")]
        public static string ArrayBufferToStringUTF8(object arrayBuffer)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement(@"String.fromCharCode.apply(null, new Uint16Array($arrayBuffer))")]
        public static string ArrayBufferToStringUTF16(object arrayBuffer)
        {
            throw new RequiresJSILRuntimeException();
        }
    }
}