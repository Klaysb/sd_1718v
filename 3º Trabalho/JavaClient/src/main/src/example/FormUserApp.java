package example;

import wcf.*;

import javax.swing.*;


public class FormUserApp {
    private JButton retrieveButton;
    private JButton deleteButton;
    private JComboBox comboBox1;
    private JComboBox comboBox2;
    private JTextArea textArea1;
    private JButton storeButton;
    private JPanel mainPanel;
    private JTextArea textArea2;
    private IBrokerService service = new BrokerService().getPort(IBrokerService.class);

    public FormUserApp() {
        storeButton.addActionListener(e -> {

            try {
                String value = textArea1.getText();
                if(value.length() == 0) {
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
                Key key = (Key) comboBox1.getSelectedItem();
                if (key == null){
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
                Key key = (Key) comboBox1.getSelectedItem();
                if(key == null){
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

    public static void main(String[] args) {
        JFrame frame = new JFrame("FormUserApp");
        frame.setContentPane(new FormUserApp().mainPanel);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
    }
}
