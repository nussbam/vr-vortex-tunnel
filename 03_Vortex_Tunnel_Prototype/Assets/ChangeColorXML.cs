using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorXML : MonoBehaviour {

    public string FilepathConfig;
    VortexTunnel vortex;

	// Use this for initialization
	void Start () {
        vortex = VortexTunnel.Load(FilepathConfig);
	}
	
	// Update is called once per frame
	void Update () {
        if (vortex != null && vortex.Abschnitt != null)
        {
            foreach(Abschnitt abschnitt in vortex.Abschnitt) {
                int red = Random.Range(abschnitt.Wandmuster.Lichter.Farbe.MinimumRot, abschnitt.Wandmuster.Lichter.Farbe.MaximumRot);
                int green = Random.Range(0, 1);
                int blue = Random.Range(0, 255);
                GetComponent<Renderer>().material.color = new Color(red, green, blue);
            }
        }
    }
}
