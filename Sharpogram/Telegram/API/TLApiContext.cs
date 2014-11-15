using System;
using System.Text;

using Telegram.TLCore;

namespace Telegram.API
{
    public class TLApiContext : TLContext
    {
        new protected void init()
        {
            registerClass(1912944108, typeof(TLUserSelf));
            registerClass(784507964, typeof(TLDcOption));
            registerClass(777313652, typeof(TLConfig));
            registerClass(-155815004, typeof(TLAuthorization));
            registerClass(-269659687, typeof(TLSentCode));
        }
    }
}
