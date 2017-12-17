using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadParamsFromXML : MonoBehaviour {

    public float durchmesser = 4;
    public LinkedList<Section> sections;
    
    
    //Loads all parameters from the xml config file
    public void LoadParams(string filepath)
    {
        VortexTunnel vortex = VortexTunnel.Load(filepath);
        sections = new LinkedList<Section>();
        durchmesser = vortex.durchmesser;

        foreach(Abschnitt abschnitt in vortex.Abschnitt)
        {
            Section temp = new Section();
            temp.anzahlLichter = abschnitt.Wandmuster.Lichter.Anzahl;
            temp.drehgeschwindigkeit = abschnitt.Wandmuster.Lichter.Drehgeschwindigkeit;
            temp.drehrichtung = abschnitt.Wandmuster.Lichter.Drehrichtung;
            temp.lichtIntensitaet = abschnitt.Wandmuster.Lichter.Intensitaet;
            temp.lichtReichweite = abschnitt.Wandmuster.Lichter.Reichweite;
            temp.texturRichtung = abschnitt.Wandmuster.Textur.Drehrichtung;
            temp.laenge = abschnitt.Laenge;

            temp.stegTextur = abschnitt.Steg.Textur;
            temp.stegBreite = abschnitt.Steg.Breite;
            temp.stegHoehe = abschnitt.Steg.Hoehe;
            temp.stegTransparenz = abschnitt.Steg.Transparenz;
            temp.gelaender = abschnitt.Steg.Gelaender;

            temp.texturgeschwindigkeit = abschnitt.Wandmuster.Textur.Drehgeschwindigkeit;
            temp.texture = abschnitt.Wandmuster.Textur.Name;

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
            Debug.Log("Abschnitt");
            
        }
    }

	

    
}
