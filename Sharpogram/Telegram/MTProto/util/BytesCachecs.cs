using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Threading;

namespace Telegram.MTProto {

    /**
 * Object for caching bytes for avoiding GC
 */
public class BytesCache {

    /**
     * Global byte cache
     *
     * @return byte cache
     */
    public static BytesCache getInstance() {
        return instance;
    }

    private static BytesCache instance = new BytesCache("GlobalByteCache");

    private readonly int[] SIZES = new int[]{64, 128, 3072, 20 * 1024, 40 * 1024};
    private const int MAX_SIZE = 40 * 1024;
    private const Boolean TRACK_ALLOCATIONS = false;

    private Dictionary<int, HashSet<byte[]>> fastBuffers = new Dictionary<int, HashSet<byte[]>>();
    private HashSet<byte[]> mainFilter = new HashSet<byte[]>();
    private HashSet<byte[]> byteBuffer = new HashSet<byte[]>();
    private ConditionalWeakTable<byte[], StackTrace[]> references = new ConditionalWeakTable<byte[], StackTrace[]>();

    private readonly String TAG;

    /**
     * Creating byte cache
     *
     * @param logTag tag for logging
     */
    public BytesCache(String logTag) {
        TAG = logTag;
        for (int i = 0; i < SIZES.Length; i++) {
            fastBuffers.Add(SIZES[i], new HashSet<byte[]>());
        }
    }

    /**
     * Put bytes to cache
     *
     * @param data bytes
     */
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void put(byte[] data) {
        references.Remove(data);

        if (mainFilter.Add(data)) {
            foreach (int i in SIZES) {
                if (data.Length == i) {
                    fastBuffers[i].Add(data);
                    return;
                }
            }
            if (data.Length <= MAX_SIZE) {
                return;
            }
            byteBuffer.Add(data);
        }
    }

    /**
     * Allocating new byte array with minimal size
     *
     * @param minSize minimal size
     * @return bytes
     */
    [MethodImpl(MethodImplOptions.Synchronized)]
    public byte[] allocate(int minSize) {
        if (minSize <= MAX_SIZE) {
            for (int i = 0; i < SIZES.Length; i++) {
                if (minSize < SIZES[i]) {
                    if (fastBuffers[SIZES[i]].Count > 0) {
                        IEnumerator<byte[]> iterator = fastBuffers[SIZES[i]].GetEnumerator();
                        iterator.MoveNext();
                        byte[] res = iterator.Current;
                        iterator.Dispose();

                        mainFilter.Remove(res);

                        if (TRACK_ALLOCATIONS) {
 //                           references.Add(res, Thread.currentThread().getStackTrace());
                        }

                        return res;
                    }

                    return new byte[SIZES[i]];
                }
            }
        } else {
            byte[] res = null;
            foreach (byte[] cached in byteBuffer) {
                if (cached.Length < minSize) {
                    continue;
                }
                if (res == null) {
                    res = cached;
                } else if (res.Length > cached.Length) {
                    res = cached;
                }
            }

            if (res != null) {
                byteBuffer.Remove(res);
                mainFilter.Remove(res);
                if (TRACK_ALLOCATIONS) {
//                    references.Add(res, Thread.currentThread().getStackTrace());
                }
                return res;
            }
        }

        return new byte[minSize];
    }
}
}
