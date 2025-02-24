
package wcf;

import java.net.MalformedURLException;
import java.net.URL;
import javax.xml.namespace.QName;
import javax.xml.ws.Service;
import javax.xml.ws.WebEndpoint;
import javax.xml.ws.WebServiceClient;
import javax.xml.ws.WebServiceException;
import javax.xml.ws.WebServiceFeature;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.2.7-b01 
 * Generated source version: 2.2
 * 
 */
@WebServiceClient(name = "BrokerService", targetNamespace = "http://tempuri.org/", wsdlLocation = "http://localhost:8736/Design_Time_Addresses/Broker/BrokerService/?wsdl")
public class BrokerService
    extends Service
{

    private final static URL BROKERSERVICE_WSDL_LOCATION;
    private final static WebServiceException BROKERSERVICE_EXCEPTION;
    private final static QName BROKERSERVICE_QNAME = new QName("http://tempuri.org/", "BrokerService");

    static {
        URL url = null;
        WebServiceException e = null;
        try {
            url = new URL("http://localhost:8736/Design_Time_Addresses/Broker/BrokerService/?wsdl");
        } catch (MalformedURLException ex) {
            e = new WebServiceException(ex);
        }
        BROKERSERVICE_WSDL_LOCATION = url;
        BROKERSERVICE_EXCEPTION = e;
    }

    public BrokerService() {
        super(__getWsdlLocation(), BROKERSERVICE_QNAME);
    }

    public BrokerService(WebServiceFeature... features) {
        super(__getWsdlLocation(), BROKERSERVICE_QNAME, features);
    }

    public BrokerService(URL wsdlLocation) {
        super(wsdlLocation, BROKERSERVICE_QNAME);
    }

    public BrokerService(URL wsdlLocation, WebServiceFeature... features) {
        super(wsdlLocation, BROKERSERVICE_QNAME, features);
    }

    public BrokerService(URL wsdlLocation, QName serviceName) {
        super(wsdlLocation, serviceName);
    }

    public BrokerService(URL wsdlLocation, QName serviceName, WebServiceFeature... features) {
        super(wsdlLocation, serviceName, features);
    }

    /**
     * 
     * @return
     *     returns IBrokerService
     */
    @WebEndpoint(name = "service")
    public IBrokerService getService() {
        return super.getPort(new QName("http://tempuri.org/", "service"), IBrokerService.class);
    }

    /**
     * 
     * @param features
     *     A list of {@link javax.xml.ws.WebServiceFeature} to configure on the proxy.  Supported features not in the <code>features</code> parameter will have their default values.
     * @return
     *     returns IBrokerService
     */
    @WebEndpoint(name = "service")
    public IBrokerService getService(WebServiceFeature... features) {
        return super.getPort(new QName("http://tempuri.org/", "service"), IBrokerService.class, features);
    }

    private static URL __getWsdlLocation() {
        if (BROKERSERVICE_EXCEPTION!= null) {
            throw BROKERSERVICE_EXCEPTION;
        }
        return BROKERSERVICE_WSDL_LOCATION;
    }

}
