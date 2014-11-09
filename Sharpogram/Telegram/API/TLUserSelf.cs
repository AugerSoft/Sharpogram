using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Telegram.TLCore;

namespace Telegram.API
{
    class TLUserSelf : TLAbsUser
    {
        override public Int64 getClassId()
        {
            return 1912944108;
        }
        override public void serializeBody(StreamWriter stream)

          {
            StreamingUtils.writeInt(this.id, stream);
            StreamingUtils.writeTLString(null, stream);
            StreamingUtils.writeTLString(null, stream);
            StreamingUtils.writeTLString(null, stream);
            StreamingUtils.writeTLObject(null, stream);
            StreamingUtils.writeTLObject(null, stream);
            StreamingUtils.writeTLBool(false, stream);
          }
  
          override public void deserializeBody(BufferedStream stream, TLContext context)

          {
            this.id = StreamingUtils.readInt(stream);
            StreamingUtils.readTLString(stream);
            StreamingUtils.readTLString(stream);
            StreamingUtils.readTLString(stream);
            StreamingUtils.readTLObject(stream, context);
            StreamingUtils.readTLObject(stream, context);
            StreamingUtils.readTLBool(stream);
          }
          public String toString()
          {
              return "userSelf#720535ec";
          }
    }
}
