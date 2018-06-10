
package BrokerService;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for Key complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Key">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="Indexes" type="{http://schemas.microsoft.com/2003/10/Serialization/Arrays}ArrayOfint" minOccurs="0"/>
 *         &lt;element name="Storages" type="{http://schemas.microsoft.com/2003/10/Serialization/Arrays}ArrayOfstring" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Key", namespace = "http://schemas.datacontract.org/2004/07/Broker", propOrder = {
    "indexes",
    "storages"
})
public class Key {

    @XmlElementRef(name = "Indexes", namespace = "http://schemas.datacontract.org/2004/07/Broker", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfint> indexes;
    @XmlElementRef(name = "Storages", namespace = "http://schemas.datacontract.org/2004/07/Broker", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfstring> storages;

    /**
     * Gets the value of the indexes property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfint }{@code >}
     *     
     */
    public JAXBElement<ArrayOfint> getIndexes() {
        return indexes;
    }

    /**
     * Sets the value of the indexes property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfint }{@code >}
     *     
     */
    public void setIndexes(JAXBElement<ArrayOfint> value) {
        this.indexes = value;
    }

    /**
     * Gets the value of the storages property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfstring }{@code >}
     *     
     */
    public JAXBElement<ArrayOfstring> getStorages() {
        return storages;
    }

    /**
     * Sets the value of the storages property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfstring }{@code >}
     *     
     */
    public void setStorages(JAXBElement<ArrayOfstring> value) {
        this.storages = value;
    }

}
