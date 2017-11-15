using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadParamsFromXML : MonoBehaviour {
    //Intro (on/off)
    public bool intro;
    public float durchmesser = 4;
    public LinkedList<Section> sections;
    
    
    //Loads all parameters from the xml config file
    public void LoadParams(string filepath)
    {
        VortexTunnel vortex = VortexTunnel.Load(filepath);
        intro = vortex.intro == "on";
        sections = new LinkedList<Section>();
        durchmesser = vortex.durchmesser;

        foreach(Abschnitt abschnitt in vortex.Abschnitt)
        {
            Section temp = new Section();
            temp.anzahlLichter = abschnitt.Wandmuster.Lichter.Anzahl;
            temp.drehgeschwindigkeit = abschnitt.Wandmuster.Lichter.Drehgeschwindigkeit;
            temp.drehrichtung = abschnitt.Wandmuster.Lichter.Drehrichtung;
            temp.laenge = abschnitt.Laenge;
            temp.steg = abschnitt.Steg;
            temp.texture = abschnitt.Wandmuster.Textur.Name;
            temp.typ = abschnitt.Typ;
            temp.minimumFarbe = new Color(
                abschnitt.Wandmuster.Lichter.Farbe.MinimumRot,
                abschnitt.Wandmuster.Lichter.Farbe.MinimumGruen,
                abschnitt.Wandmuster.Lichter.Farbe.MinimumBlau
                );
            temp.maximumFarbe = new Color(
                abschnitt.Wandmuster.Lichter.Farbe.MaximumRot,
                abschnitt.Wandmuster.Lichter.Farbe.MaximumGruen,
                abschnitt.Wandmuster.Lichter.Farbe.MaximumBlau
                );

            sections.AddLast(temp);
            Debug.Log("Abschitt");
            
        }
    }

	

    
}
