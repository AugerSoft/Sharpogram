using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Telegram.TLCore;


namespace Telegram.API
{
    public class TLRequestAuthSendCall : TLMethod<TLBool>
    {
        public static readonly Int64 CLASS_ID = 63247716;
        protected String phoneNumber;
        protected String phoneCodeHash;
  
        override public Int64 getClassId()
        {
            return 63247716;
        }
  
        public TLRequestAuthSendCall(String _phoneNumber, String _phoneCodeHash)
        {
            this.phoneNumber = _phoneNumber;
            this.phoneCodeHash = _phoneCodeHash;
        }
  
        public TLBool deserializeResponse(BufferedStream stream, TLContext context)
        {
            try {
                TLObject res = StreamingUtils.readTLObject(stream, context);
                if (res == null) {
                    throw new IOException("Unable to parse response");
                }
                if ((res is TLBool)) {
                    return (TLBool)res;
                }
                throw new IOException("Incorrect response type. Expected TLBool, got: " + res.GetType().Name);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                throw e;
            }
        }
  
        public String getPhoneNumber()
        {
            return this.phoneNumber;
        }
  
        public void setPhoneNumber(String value)
        {
            this.phoneNumber = value;
        }
  
        public String getPhoneCodeHash()
        {
            return this.phoneCodeHash;
        }
  
        public void setPhoneCodeHash(String value)
        {
            this.phoneCodeHash = value;
        }
  
        override public void serializeBody(StreamWriter stream)
        {
            try {
                StreamingUtils.writeTLString(this.phoneNumber, stream);
                StreamingUtils.writeTLString(this.phoneCodeHash, stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
  
        override public void deserializeBody(BufferedStream stream, TLContext context)
        {
            try {
                this.phoneNumber = StreamingUtils.readTLString(stream);
                this.phoneCodeHash = StreamingUtils.readTLString(stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
  
        public String toString()
        {
            return "auth.sendCall#3c51564";
        }
    }
}
