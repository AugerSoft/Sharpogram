using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Telegram.TLCore
{
    public class TLLastKnownSalt : TLObject {

        public static readonly Int64 CLASS_ID = 0x0f054c60;

        private Int64 validSince;
        private Int64 validUntil;
        private long salt;

        public TLLastKnownSalt(Int64 validSince, Int64 validUntil, long salt) {
            this.validSince = validSince;
            this.validUntil = validUntil;
            this.salt = salt;
        }

        public TLLastKnownSalt() {

        }

        public Int64 getValidSince() {
            return validSince;
        }

        public Int64 getValidUntil() {
            return validUntil;
        }

        public long getSalt() {
            return salt;
        }

        override public Int64 getClassId() {
            return CLASS_ID;
        }

        override public void serializeBody(StreamWriter stream) {
            StreamingUtils.writeInt(validSince, stream);
            StreamingUtils.writeInt(validUntil, stream);
            StreamingUtils.writeLong(salt, stream);
        }

        override public void deserializeBody(BufferedStream stream, TLContext context) {
            validSince = StreamingUtils.readInt(stream);
            validUntil = StreamingUtils.readInt(stream);
            salt = StreamingUtils.readLong(stream);
        }
    }
}
