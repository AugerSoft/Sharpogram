using System;
using System.Text;

namespace Telegram.API
{
    public abstract class AbsApiCallback
    {
        public abstract void onAuthCancelled(TelegramApi api);

        public abstract void onUpdatesInvalidated(TelegramApi api);

        public abstract void onUpdate(TLAbsUpdates updates);
    }
}