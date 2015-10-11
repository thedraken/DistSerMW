using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_RPC_Server
{

    /// <summary>
    /// Enumeration of the modes in which JSON-RPC requests shall be processed.
    /// </summary>
    public enum ServiceMode
    {
        /// <summary>
        /// Process requests in a reliable way, i.e. without disconnections, interruptions, crashes, or alike.
        /// </summary>
        RELIABLE,

        /// <summary>
        /// Close the connection before handling the request in any way. Please note
        /// that no interceptor will be called in this mode.
        /// </summary>
        DISCONNECT_BEFORE_PROCESSING,

        /// <summary>
        /// Close the connection after having processed the request, but before
        /// sending back the response. Please note that in this mode, the
        /// interceptor will be called for both the request as well as the response. 
        /// </summary>
        DISCONNECT_BEFORE_REPLY,

        /// <summary>
        /// The service mode will be determined randomly for every subsequent
        /// request. This includes all three other modes, i.e. RELIABLE,
        /// DISCONNECT_BEFORE_PROCESSING, and DISCONNECT_BEFORE_REPLY.
        /// Please note that by definition of the two latter modes, the
        /// connection will be closed in those cases. If the randomly
        /// selected service mode is RELIABLE, however, the next request
        /// will be handled in a reliable fashion, keeping the connection
        /// alive. For each subsequent request, a service mode will again
        /// be chosen randomly.
        /// </summary>
        RANDOM
    };

}
