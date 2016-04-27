using JSIL;
using JSIL.Meta;

namespace SharpJS.JSLibraries
{
    public class BufferConverter
    {
        [JSReplacement(@"String.fromCharCode.apply(null, new Uint16Array($arrayBuffer));")]
        public static string ArrayBufferToString(object arrayBuffer)
        {
            throw new RequiresJSILRuntimeException();
        }

        public static object StringToArrayBuffer(string str)
        {
            object buf = str;
            Verbatim.Expression(@"
                  buf = new ArrayBuffer(str.length*2); //2 bytes for each char
                  var bufView = new Uint16Array(buf);
                  for (var i=0, strLen=str.length; i<strLen; i++) {
                    bufView[i] = str.charCodeAt(i);
                  }
            ");
            return buf;
        }
    }
}