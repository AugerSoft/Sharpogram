using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Telegram.TLCore
{
    public class TLStorage : TLObject {

        public static readonly Int64 CLASS_ID = 0x3ef9c4b4;

        private TLVector<TLKey> keys;

        private TLVector<TLDcInfo> dcInfos;

        private Int64 primaryDc;

        private Boolean isbAuthorized;

        private Int64 uid;

        private String phone;

        public TLStorage() {
            keys = new TLVector<TLKey>();
            dcInfos = new TLVector<TLDcInfo>();
            primaryDc = 1;
            isbAuthorized = false;
            uid = 0;
            phone = "";
        }

        public TLVector<TLKey> getKeys() {
            return keys;
        }

        public TLVector<TLDcInfo> getDcInfos() {
            return dcInfos;
        }

        public Int64 getPrimaryDc() {
            return primaryDc;
        }

        public void setPrimaryDc(Int64 primaryDc) {
            this.primaryDc = primaryDc;
        }

        public Boolean isAuthorized() {
            return isbAuthorized;
        }

        public void setAuthorized(Boolean authorized) {
            isbAuthorized = authorized;
        }

        public Int64 getUid() {
            return uid;
        }

        public void setUid(Int64 uid) {
            this.uid = uid;
        }

        public String getPhone() {
            return phone;
        }

        public void setPhone(String phone) {
            this.phone = phone;
        }

        override public Int64 getClassId() {
            return CLASS_ID;
        }

        override public void serializeBody(StreamWriter stream) {
            try {
                StreamingUtils.writeTLVector(keys, stream);
                StreamingUtils.writeTLVector(dcInfos, stream);
                StreamingUtils.writeInt(primaryDc, stream);
                StreamingUtils.writeTLBool(isbAuthorized, stream);
                StreamingUtils.writeInt(uid, stream);
                StreamingUtils.writeTLString(phone, stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        override public void deserializeBody(BufferedStream stream, TLContext context) {
            try {
                keys = (TLVector<TLKey>)StreamingUtils.readTLVector(stream, context);
                dcInfos = (TLVector<TLDcInfo>)StreamingUtils.readTLVector(stream, context);
                primaryDc = StreamingUtils.readInt(stream);
                isbAuthorized = StreamingUtils.readTLBool(stream);
                uid = StreamingUtils.readInt(stream);
                phone = StreamingUtils.readTLString(stream);
            } catch(IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
    }
}
