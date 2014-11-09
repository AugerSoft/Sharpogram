using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.TLCore
{
    public class TLKey : TLObject {

        public static readonly Int64 CLASS_ID = 0x4a861b1a;

        private Int64 dcId;

        private byte[] authKey;

        private Boolean isbAuthorised;

        private TLVector<TLLastKnownSalt> salts;

        private TLVector<TLOldSession> oldSessions;

        public TLKey(int dcId, byte[] authKey) {
            this.dcId = dcId;
            this.authKey = authKey;
            this.isbAuthorised = false;
            this.salts = new TLVector<TLLastKnownSalt>();
            this.oldSessions = new TLVector<TLOldSession>();
        }

        public TLKey() {

        }

        public Int64 getDcId() {
            return dcId;
        }

        public byte[] getAuthKey() {
            return authKey;
        }

        public Boolean isAuthorised() {
            return isbAuthorised;
        }

        public void setAuthorised(Boolean authorised) {
            isbAuthorised = authorised;
        }

        public TLVector<TLLastKnownSalt> getSalts() {
            return salts;
        }

        public TLVector<TLOldSession> getOldSessions() {
            return oldSessions;
        }

        override public Int64 getClassId() {
            return CLASS_ID;
        }

        override public void serializeBody(StreamWriter stream) {
            try
            {
                StreamingUtils.writeInt(dcId, stream);
                StreamingUtils.writeByteArray(authKey, stream);
                StreamingUtils.writeTLBool(isbAuthorised, stream);
                StreamingUtils.writeTLVector(salts, stream);
                StreamingUtils.writeTLVector(oldSessions, stream);
            }
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        override public void deserializeBody(BufferedStream stream, TLContext context) {
            try {
                dcId = StreamingUtils.readInt(stream);
                authKey = StreamingUtils.readBytes(256, stream);
                isbAuthorised = StreamingUtils.readTLBool(stream);
                salts = (TLVector<TLLastKnownSalt>)StreamingUtils.readTLVector(stream, context);
                oldSessions = (TLVector<TLOldSession>)StreamingUtils.readTLVector(stream, context);
            }
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
    }
}
