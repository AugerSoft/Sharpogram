using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telegram.TLCore
{
    public class TLOldSession : TLObject {
        public static readonly Int64 CLASS_ID = 0x8b973f91;

        private byte[] session;

        public TLOldSession(byte[] session) {
            this.session = session;
        }

        public TLOldSession() {

        }

        public byte[] getSession() {
            return session;
        }

        override public Int64 getClassId() {
            return CLASS_ID;
        }

        override public void serializeBody(StreamWriter stream) {
            try {
                StreamingUtils.writeByteArray(session, stream);
            }
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        override public void deserializeBody(BufferedStream stream, TLContext context) {
            try {
                session = StreamingUtils.readBytes(8, stream);
            }
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
    }
}
