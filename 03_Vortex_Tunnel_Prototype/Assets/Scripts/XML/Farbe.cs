using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Farbe{
    [XmlElement]
    public float MinimumRot;
    [XmlElement]
    public float MaximumRot;
    [XmlElement]
    public float MinimumGruen;
    [XmlElement]
    public float MaximumGruen;
    [XmlElement]
    public float MinimumBlau;
    [XmlElement]
    public float MaximumBlau;


}
