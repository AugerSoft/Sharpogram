using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.TLCore;

namespace Telegram.API
{
    public abstract class TLAbsUser : TLObject {
        protected Int64 id;
  
        public Int64 getId()
        {
            return this.id;
        }
  
        public void setId(Int64 value)
        {
            this.id = value;
        }
    }
}
