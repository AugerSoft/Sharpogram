using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Telegram.TLCore;

namespace Telegram.API
{
    public class TLAuthorization : TLObject {
        public static readonly Int64 CLASS_ID = -155815004;
        protected Int64 expires;
        protected TLAbsUser user;
  
        public TLAuthorization() {}
  
        public TLAuthorization(Int64 _expires, TLAbsUser _user)
        {
            this.expires = _expires;
            this.user = _user;
        }
  
        override public Int64 getClassId()
        {
            return -155815004;
        }
  
        public Int64 getExpires()
        {
            return this.expires;
        }
  
        public void setExpires(Int64 value)
        {
            this.expires = value;
        }
  
        public TLAbsUser getUser()
        {
            return this.user;
        }
  
        public void setUser(TLAbsUser value)
        {
            this.user = value;
        }
  
        override public void serializeBody(StreamWriter stream)
        {
            try {
                StreamingUtils.writeInt(this.expires, stream);
                StreamingUtils.writeTLObject(this.user, stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
  
        override public void deserializeBody(BufferedStream stream, TLContext context)
        {
            try {
                this.expires = StreamingUtils.readInt(stream);
                this.user = ((TLAbsUser)StreamingUtils.readTLObject(stream, context));
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
  
        public String toString()
        {
            return "auth.authorization#f6b673a4";
        }
    }
}
