using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

using Telegram.TLCore;
using Telegram.MTProto;

namespace Telegram.API
{
    class TLSampleApiContext : TLApiContext {

//        private AtomicInteger integer = new AtomicInteger(0);

        new public TLObject deserializeMessage(Int64 clazzId, BufferedStream stream) {
            try {
                /*
                if (integer.incrementAndGet() % 10 == 9) {
                    Thread.Yield();
                }
                */
                return base.deserializeMessage(clazzId, stream);
            } catch (IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                throw e;
            }
        }

        new public TLBytes allocateBytes(int size) {
            return new TLBytes(BytesCache.getInstance().allocate(size), 0, size);
        }

        new public void releaseBytes(TLBytes unused) {
            BytesCache.getInstance().put(unused.getData());
        }
    }
}
