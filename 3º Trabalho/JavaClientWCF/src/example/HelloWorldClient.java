package example;

import BrokerService.BrokerService;
import BrokerService.IBrokerService;
import BrokerService.IBrokerServiceRetrieveDataArgumentExceptionFaultFaultMessage;
import BrokerService.IBrokerServiceStoreDataInvalidOperationExceptionFaultFaultMessage;
import BrokerService.Key;

public class HelloWorldClient {
  public static void main(String[] argv) throws IBrokerServiceStoreDataInvalidOperationExceptionFaultFaultMessage, IBrokerServiceRetrieveDataArgumentExceptionFaultFaultMessage {
    IBrokerService service = new BrokerService().getPort(IBrokerService.class);
    //invoke business method
    Key k = service.storeData("oi");
    System.out.println(service.retrieveData(k));
  }
}
