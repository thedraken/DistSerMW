using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_RPC_Server
{

    public enum ServiceMode
    {
        RELIABLE,
        DISCONNECT_BEFORE_PROCESSING,
        DISCONNECT_BEFORE_REPLY,
        RANDOM
    };

}
