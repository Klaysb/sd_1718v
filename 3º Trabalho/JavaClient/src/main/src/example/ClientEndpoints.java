package example;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class ClientEndpoints {

    private String[] baseAddress;

    public String[] getBaseAddress() {
        return baseAddress;
    }

    @XmlElement
    public void setBaseAddress(String[] baseAddress) {
        this.baseAddress = baseAddress;
    }
}
