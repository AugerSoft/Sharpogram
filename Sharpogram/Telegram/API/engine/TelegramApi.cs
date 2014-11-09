using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Telegram.TLCore;
using Telegram.MTProto;

namespace Telegram.API
{
    // Based on (@author Korshakov Stepan <me@ex3ndr.com> for Java)

    public class TelegramApi
    {/*
        public static const int MODE_FULL_POWER = 0;
        public static const int MODE_LOW_POWER = 1;

        private static const int DEFAULT_TIMEOUT = 15000;

        private static const AtomicInteger rpcCallIndex = new AtomicInteger(0);
        private static const AtomicInteger instanceIndex = new AtomicInteger(1000);

        private readonly String TAG;
        private readonly int INSTANCE_INDEX;

        private ActorSystem actorSystem;
        private AbsApiCallback apiCallback;
        private AppInfo appInfo;
        private AbsApiState state;

        private int primaryDc;
        private Boolean isClosed;

        private ProtoCallback callback;
        private int mode;

        private TLApiContext apiContext;

        public TelegramApi(AbsApiState state, AppInfo _appInfo, AbsApiCallback _apiCallback) {
            this.INSTANCE_INDEX = instanceIndex.incrementAndGet();
            this.TAG = "TelegramApi#" + INSTANCE_INDEX;
            this.actorSystem = new ActorSystem();
            this.actorSystem.addThread("connector");

            long start = TimeOverlord.CurrentTimeMillis();
            this.apiCallback = _apiCallback;
            this.appInfo = _appInfo;
            this.state = state;
            this.primaryDc = state.getPrimaryDc();
            this.isClosed = false;
            this.callback = new ProtoCallback();
            this.mode = MODE_FULL_POWER;
            Logger.d(TAG, "Phase 0 in " + (TimeOverlord.CurrentTimeMillis() - start) + " ms");

            start = TimeOverlord.CurrentTimeMillis();
            
            this.apiContext = new TLSampleApiContext();

            Logger.d(TAG, "Phase 1 in " + (TimeOverlord.CurrentTimeMillis() - start) + " ms");

            start = TimeOverlord.CurrentTimeMillis();
            this.timeoutThread = new TimeoutThread();
            this.timeoutThread.start();

            this.dcThread = new ConnectionThread();
            this.dcThread.start();

            this.senderThread = new SenderThread();
            this.senderThread.start();
            Logger.d(TAG, "Phase 2 in " + (TimeOverlord.CurrentTimeMillis() - start) + " ms");

            start = TimeOverlord.CurrentTimeMillis();
            this.downloader = new Downloader(this);
            this.uploader = new Uploader(this);
            Logger.d(TAG, "Phase 3 in " + (TimeOverlord.CurrentTimeMillis() - start) + " ms");
        }

        public T doRpcCallNonAuth<T>(TLMethod<T> method, int timeout, int dcId) where T : TLObject
        {
            try {
                return doRpcCall<T>(method, DEFAULT_TIMEOUT, dcId, false);
            } catch (IOException e) {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                throw e;
            }
        }

        private T doRpcCall<T>(TLMethod<T> method, int timeout, int destDc, Boolean authRequired) where T : TLObject {
            if (isClosed) {
                throw new TimeoutException();
            }
            Object waitObj = new Object();
            Object[] res = new Object[3];
            Boolean[] completed = new Boolean[1];
            completed[0] = false;

            doRpcCall(method, timeout, new RpcCallback<T>() {

                override public void onResult(T result) {
                    synchronized (waitObj) {
                        if (completed[0]) {
                            return;
                        }
                        completed[0] = true;
                        res[0] = result;
                        res[1] = null;
                        res[2] = null;
                        waitObj.notifyAll();
                    }
                }

                override public void onError(int errorCode, String message) {
                    synchronized (waitObj) {
                        if (completed[0]) {
                            return;
                        }
                        completed[0] = true;
                        res[0] = null;
                        res[1] = errorCode;
                        res[2] = message;
                        waitObj.notifyAll();
                    }
                }
            }, destDc, authRequired);

            synchronized (waitObj) {
                try {
                    waitObj.wait(timeout);
                    completed[0] = true;
                } catch (InterruptedException e) {
                    throw new TimeoutException();
                }
            }

            if (res[0] == null) {
                if (res[1] != null) {
                    Integer code = (Integer) res[1];
                    if (code == 0) {
                        throw new TimeoutException();
                    } else {
                        throw new RpcException(code, (String) res[2]);
                    }
                } else {
                    throw new TimeoutException();
                }
            } else {
                return (T) res[0];
            }
        }
        */
    }
}
