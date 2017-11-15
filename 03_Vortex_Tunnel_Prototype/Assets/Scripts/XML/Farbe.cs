using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Farbe{
    [XmlElement]
    public int MinimumRot;
    [XmlElement]
    public int MaximumRot;
    [XmlElement]
    public int MinimumGruen;
    [XmlElement]
    public int MaximumGruen;
    [XmlElement]
    public int MinimumBlau;
    [XmlElement]
    public int MaximumBlau;


}
