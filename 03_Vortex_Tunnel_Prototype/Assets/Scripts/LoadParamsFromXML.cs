using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadParamsFromXML : MonoBehaviour {
    //Intro (on/off)
    public bool intro = false;

    //Strecke
    public float laenge = 20;
    public float durchmesser = 4;
    public string kurve = "keine";
    public string steg = "gitter";

    //Muster
    public int punktdichte = 50;
    public string drehrichtung = "rechts";
    public int drehgeschwindigkeit = 50;
    public Color minimumFarbe = new Color(0,0,0);
    public Color maximumFarbe = new Color(1,1,1);

    //Loads all parameters from the xml config file
    public void LoadParams()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
