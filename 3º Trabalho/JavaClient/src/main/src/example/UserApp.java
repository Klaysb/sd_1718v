package example;

import wcf.*;

public class UserApp {

    public static void main(String[] argv) throws IBrokerServiceStoreDataInvalidOperationExceptionFaultFaultMessage, IBrokerServiceRetrieveDataArgumentExceptionFaultFaultMessage {
        IBrokerService service = new BrokerService().getPort(IBrokerService.class);
        //invoke business method
        Key abc = service.storeData("abc");
        String s = service.retrieveData(abc);
        System.out.println(s);
    }
}
