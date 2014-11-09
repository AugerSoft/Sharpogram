using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.TLCore
{
    public class TLDcInfo : TLObject {

    public static readonly Int64 CLASS_ID = 0x3db4ea98;

    private Int64 dcId;
    private String address;
    private Int64 port;
    private Int64 version;

    public TLDcInfo(Int64 dcId, String address, Int64 port, Int64 version) {
        this.dcId = dcId;
        this.address = address;
        this.port = port;
        this.version = version;
    }

    public TLDcInfo() {

    }

    public Int64 getDcId() {
        return dcId;
    }

    public String getAddress() {
        return address;
    }

    public Int64 getPort() {
        return port;
    }

    public Int64 getVersion() {
        return version;
    }

    override public Int64 getClassId() {
        return CLASS_ID;
    }

    override public void serializeBody(StreamWriter stream) {
        StreamingUtils.writeInt(dcId, stream);
        StreamingUtils.writeTLString(address, stream);
        StreamingUtils.writeInt(port, stream);
        StreamingUtils.writeInt(version, stream);
    }

    override public void deserializeBody(BufferedStream stream, TLContext context) {
        dcId = StreamingUtils.readInt(stream);
        address = StreamingUtils.readTLString(stream);
        port = StreamingUtils.readInt(stream);
        version = StreamingUtils.readInt(stream);
    }
}
}
