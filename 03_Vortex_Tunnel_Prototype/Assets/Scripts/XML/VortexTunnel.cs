using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("VortexTunnel")]
public class VortexTunnel {
    [XmlAttribute("intro")]
    public string intro;
    [XmlAttribute("durchmesser")]
    public float durchmesser;
    [XmlArray("Abschnitte"),XmlArrayItem("Abschnitt")]
    public Abschnitt[] Abschnitt;
    


    public static VortexTunnel Load(string path)
    {
        var serializer = new XmlSerializer(typeof(VortexTunnel));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as VortexTunnel;
        }
    }


	
}
