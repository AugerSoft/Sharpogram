using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Telegram.TLCore;

namespace Telegram.API
{
    public class TLSentCode : TLObject {
        public static readonly Int64 CLASS_ID = -269659687;
        protected Boolean phoneRegistered;
        protected String phoneCodeHash;
        protected Int64 sendCallTimeout;
        protected Boolean isPassword;
  
        public TLSentCode() {}
  
        public TLSentCode(Boolean _phoneRegistered, String _phoneCodeHash, Int64 _sendCallTimeout, Boolean _isPassword)
        {
            this.phoneRegistered = _phoneRegistered;
            this.phoneCodeHash = _phoneCodeHash;
            this.sendCallTimeout = _sendCallTimeout;
            this.isPassword = _isPassword;
        }
  
        override public Int64 getClassId()
        {
            return -269659687;
        }
  
        public Boolean getPhoneRegistered()
        {
            return this.phoneRegistered;
        }
  
        public void setPhoneRegistered(Boolean value)
        {
            this.phoneRegistered = value;
        }
  
        public String getPhoneCodeHash()
        {
            return this.phoneCodeHash;
        }
  
        public void setPhoneCodeHash(String value)
        {
            this.phoneCodeHash = value;
        }

        public Int64 getSendCallTimeout()
        {
            return this.sendCallTimeout;
        }

        public void setSendCallTimeout(Int64 value)
        {
            this.sendCallTimeout = value;
        }
  
        public Boolean getIsPassword()
        {
            return this.isPassword;
        }
  
        public void setIsPassword(Boolean value)
        {
            this.isPassword = value;
        }

        override public void serializeBody(StreamWriter stream)
        {
            try {
                StreamingUtils.writeTLBool(this.phoneRegistered, stream);
                StreamingUtils.writeTLString(this.phoneCodeHash, stream);
                StreamingUtils.writeInt(this.sendCallTimeout, stream);
            StreamingUtils.writeTLBool(this.isPassword, stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        override public void deserializeBody(BufferedStream stream, TLContext context)
        {
            try {
                this.phoneRegistered = StreamingUtils.readTLBool(stream);
                this.phoneCodeHash = StreamingUtils.readTLString(stream);
                this.sendCallTimeout = StreamingUtils.readInt(stream);
                this.isPassword = StreamingUtils.readTLBool(stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
  
        public String toString()
        {
            return "auth.sentCode#efed51d9";
        }
    }
}
