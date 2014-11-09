using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Telegram.TLCore;

namespace Telegram.API
{
    public class TLRequestHelpGetConfig : TLMethod<TLConfig> {
        public static readonly Int64 CLASS_ID = -990308245;
  
        override public Int64 getClassId()
        {
            return -990308245;
        }
  
        public TLConfig deserializeResponse(BufferedStream stream, TLContext context)
        {
            try {
            TLObject res = StreamingUtils.readTLObject(stream, context);
            if (res == null) {
                throw new IOException("Unable to parse response");
            }

            if ((res is TLConfig)) {
                return (TLConfig)res;
            }
            throw new IOException("Incorrect response type. Expected TLConfig, got: " + res.GetType().Name);
            } catch (IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                throw e;
            }
        }
  
        public String toString()
        {
            return "help.getConfig#c4f9186b";
        }

        override public void deserializeBody(BufferedStream stream, TLContext context) { }
        override public void serializeBody(StreamWriter stream) { }
    }
}
