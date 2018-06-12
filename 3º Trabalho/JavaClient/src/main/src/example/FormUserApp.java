package example;

import wcf.*;

import javax.swing.*;
import javax.swing.event.PopupMenuEvent;
import javax.swing.event.PopupMenuListener;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;

public class FormUserApp {

    private final static String FILE_NAME = "clientEndpoints.xml";

    private JButton retrieveButton;
    private JButton deleteButton;
    private JComboBox comboBox1;
    private JComboBox comboBox2;
    private JTextArea textArea1;
    private JButton storeButton;
    private JPanel mainPanel;
    private JTextArea textArea2;
    private IBrokerService service = null;

    public FormUserApp() {
        comboBox2.addPopupMenuListener(new PopupMenuListener() {
            private boolean firstTime = true;

            @Override
            public void popupMenuWillBecomeVisible(PopupMenuEvent e) {
                if (firstTime) {
                    for (String baseAddress : baseAddresses)
                        comboBox2.addItem(baseAddress);
                    firstTime = false;
                }
            }

            @Override
            public void popupMenuWillBecomeInvisible(PopupMenuEvent e) {
                String baseAddress = (String) ((JComboBox) e.getSource()).getSelectedItem();
                try {
                    service = new BrokerService(new URL(baseAddress)).getPort(IBrokerService.class);
                } catch (MalformedURLException e1) {
                    JOptionPane.showMessageDialog(null, "Bad broker.");
                }
            }

            @Override
            public void popupMenuCanceled(PopupMenuEvent e) {

            }
        });

        storeButton.addActionListener(e -> {
            try {
                if (service == null) {
                    JOptionPane.showMessageDialog(null, "Please specify the broker.");
                    return;
                }
                String value = textArea1.getText();
                if (value.length() == 0) {
                    JOptionPane.showMessageDialog(null, "Please specify the value.");
                    return;
                }
                Key key = service.storeData(value);
                comboBox1.addItem(key);
                textArea1.setText("");
            } catch (IBrokerServiceStoreDataInvalidOperationExceptionFaultFaultMessage iBrokerServiceStoreDataInvalidOperationExceptionFaultFaultMessage) {
                JOptionPane.showMessageDialog(null, "Could not save value.");
            }
        });

        retrieveButton.addActionListener(e -> {
            try {
                if (service == null) {
                    JOptionPane.showMessageDialog(null, "Please specify the broker.");
                    return;
                }
                Key key = (Key) comboBox1.getSelectedItem();
                if (key == null) {
                    JOptionPane.showMessageDialog(null, "Please select key.");
                    return;
                }
                String value = service.retrieveData(key);
                textArea2.setText("");
                textArea2.append(value);
            } catch (IBrokerServiceRetrieveDataArgumentExceptionFaultFaultMessage iBrokerServiceRetrieveDataArgumentExceptionFaultFaultMessage) {
                JOptionPane.showMessageDialog(null, "Could not retrieve value associated with the selected key.");
            }
        });

        deleteButton.addActionListener(e -> {
            try {
                if (service == null) {
                    JOptionPane.showMessageDialog(null, "Please specify the broker.");
                    return;
                }
                Key key = (Key) comboBox1.getSelectedItem();
                if (key == null) {
                    JOptionPane.showMessageDialog(null, "Please select key.");
                    return;
                }
                service.deleteData(key);
                comboBox1.removeItem(comboBox1.getSelectedItem());
            } catch (IBrokerServiceDeleteDataArgumentExceptionFaultFaultMessage iBrokerServiceDeleteDataArgumentExceptionFaultFaultMessage) {
                JOptionPane.showMessageDialog(null, "Could not delete value associated with the selected key.");
            }
        });
    }

    private static String[] baseAddresses;

    public static void main(String[] args) {
        ClientEndpoints clientEndpoints = getClientEndpoints();
        if (clientEndpoints != null) {
            baseAddresses = clientEndpoints.getBaseAddress();
            JFrame frame = new JFrame("FormUserApp");
            frame.setContentPane(new FormUserApp().mainPanel);
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.pack();
            frame.setVisible(true);
        }
    }

    private static ClientEndpoints getClientEndpoints() {
        try {
            File file = new File(FILE_NAME);
            JAXBContext jaxbContext = JAXBContext.newInstance(ClientEndpoints.class);
            Unmarshaller jaxbUnmarshaller = jaxbContext.createUnmarshaller();
            return (ClientEndpoints) jaxbUnmarshaller.unmarshal(file);
        } catch (JAXBException e) {
            System.out.println("Cannot load " + FILE_NAME);
            return null;
        }
    }
}
