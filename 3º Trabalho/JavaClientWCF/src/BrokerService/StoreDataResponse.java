
package BrokerService;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="StoreDataResult" type="{http://schemas.datacontract.org/2004/07/Broker}Key" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "storeDataResult"
})
@XmlRootElement(name = "StoreDataResponse")
public class StoreDataResponse {

    @XmlElementRef(name = "StoreDataResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<Key> storeDataResult;

    /**
     * Gets the value of the storeDataResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Key }{@code >}
     *     
     */
    public JAXBElement<Key> getStoreDataResult() {
        return storeDataResult;
    }

    /**
     * Sets the value of the storeDataResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Key }{@code >}
     *     
     */
    public void setStoreDataResult(JAXBElement<Key> value) {
        this.storeDataResult = value;
    }

}
