using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Telegram.TLCore;

namespace Telegram.API
{
    public class TLRequestAuthSendCode : TLMethod<TLSentCode>
    {
        public static readonly Int64 CLASS_ID = 1988976461;
        protected String phoneNumber;
        protected Int64 smsType;
        protected Int64 apiId;
        protected String apiHash;
        protected String langCode;
  
        override public Int64 getClassId()
        {
            return 1988976461;
        }
  
        public TLRequestAuthSendCode(String _phoneNumber, int _smsType, int _apiId, String _apiHash, String _langCode)
        {
            this.phoneNumber = _phoneNumber;
            this.smsType = _smsType;
            this.apiId = _apiId;
            this.apiHash = _apiHash;
            this.langCode = _langCode;
        }
  
        public TLSentCode deserializeResponse(BufferedStream stream, TLContext context)
        {
            try {
                TLObject res = StreamingUtils.readTLObject(stream, context);
                if (res == null) {
                    throw new IOException("Unable to parse response");
                }
                if ((res is TLSentCode)) {
                    return (TLSentCode)res;
                }
                throw new IOException("Incorrect response type. Expected TLSentCode, got: " + res.GetType().Name);
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
  
        public Int64 getSmsType()
        {
            return this.smsType;
        }
  
        public void setSmsType(int value)
        {
            this.smsType = value;
        }
  
        public Int64 getApiId()
        {
            return this.apiId;
        }
  
        public void setApiId(int value)
        {
            this.apiId = value;
        }
  
        public String getApiHash()
        {
            return this.apiHash;
        }
  
        public void setApiHash(String value)
        {
            this.apiHash = value;
        }
  
        public String getLangCode()
        {
            return this.langCode;
        }
  
        public void setLangCode(String value)
        {
            this.langCode = value;
        }
  
        override public void serializeBody(StreamWriter stream)
        {
            try {
                StreamingUtils.writeTLString(this.phoneNumber, stream);
                StreamingUtils.writeInt(this.smsType, stream);
                StreamingUtils.writeInt(this.apiId, stream);
                StreamingUtils.writeTLString(this.apiHash, stream);
                StreamingUtils.writeTLString(this.langCode, stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                throw e;
            }
        }
  
        override public void deserializeBody(BufferedStream stream, TLContext context)
        {
            try {
                this.phoneNumber = StreamingUtils.readTLString(stream);
                this.smsType = StreamingUtils.readInt(stream);
                this.apiId = StreamingUtils.readInt(stream);
                this.apiHash = StreamingUtils.readTLString(stream);
                this.langCode = StreamingUtils.readTLString(stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                throw e;
            }
        }
  
        public String toString()
        {
            return "auth.sendCode#768d5f4d";
        }
    }
}
