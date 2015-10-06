package lu.uni.distributedsystems.gsonrmi.server;

import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.logging.Logger;

import com.google.code.gsonrmi.annotations.RMI;

/**
 * Base class for a JSON-RPC server. The purpose of this class is to export
 * a remote interface that allows a client to determine how JSON-RPC requests
 * should be processed via setting a service mode.
 */
public class BaseServer {
		
	// directory of service modes, per connection
	private static Map<IPEndpoint, ServiceMode> serviceModes = new ConcurrentHashMap<IPEndpoint, ServiceMode>();
	// logger for debugging purposes
	private static Logger logger = Logger.getLogger(BaseServer.class.getName());
	
	/**
	 * Remotely accessible method that allows to determine how requests from a certain
	 * connection end point will be processed.
	 * Handles JSON-RPC invocations like : {'method':'setModeOfHost', 'params':['192.168.1.100','RELIABLE'],'id':1}
	 * 
	 * @param ipAddress	IP address of the client-side connection end point
	 * @param port		port number of the client-side connection end point
	 * @param mode		mode in which subsequent requests shall be processed
	 */
	@RMI
    public void setModeOfHost(String ipAddress, int port, ServiceMode mode)
    {
        try {
        	IPEndpoint ipEndpoint = new IPEndpoint(InetAddress.getByName(ipAddress), port);
        	
			setServiceMode(ipEndpoint, mode);
		} catch (UnknownHostException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    }

	/**
	 * Allows to set the service mode for a certain connection end point, determining
	 * how requests from that connection will be processed.
	 * 
	 * @param ipEndpoint	IP address and port number of the client-side connection end point
	 * @param mode			mode in which subsequent requests shall be processed
	 */
	public static void setServiceMode(IPEndpoint ipEndpoint, ServiceMode mode) {
        logger.info("set mode of host: " + ipEndpoint + " to: " + mode);
        // remember service mode selected
        serviceModes.put(ipEndpoint, mode);
	}
	
	/**
	 * Retrieves the currently selected service mode for the given client-side end point.
	 * In case no service mode has been set explicitly yet, the default mode returned
	 * is RELIABLE.
	 * 
	 * @param ipEndpoint	IP address and port number of the client-side connection end point
	 * @return				current mode in which requests shall be processed
	 */
	public static ServiceMode getServiceMode(IPEndpoint ipEndpoint) {
		// retrieve service mode for a certain connection end point
		if (serviceModes.containsKey(ipEndpoint))
			return serviceModes.get(ipEndpoint);
		// default service mode is RELIABLE
		return ServiceMode.RELIABLE;
	}
	

}
