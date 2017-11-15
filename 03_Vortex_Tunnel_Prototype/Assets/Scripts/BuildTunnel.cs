using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTunnel : MonoBehaviour {

    private LoadParamsFromXML tunnelParams = new LoadParamsFromXML();
 
	// Create the tunnel
	void Start () {
        tunnelParams.LoadParams("C://temp//vortexparams.xml");


        float distance = 0;
        foreach(Section section in tunnelParams.sections)
        {

            
            GameObject tunnel = (GameObject)Instantiate(Resources.Load("Tunnel_Straight"));
            tunnel.transform.position = new Vector3(0, 0, distance);
            //Modify Tunnel Object according to params
            tunnel.transform.localScale = new Vector3(tunnelParams.durchmesser, tunnelParams.durchmesser, section.laenge);
            

            //Create Spotlights along the tunnel

            for (int i = 0; i < section.anzahlLichter; i++)
            {

                GameObject spotlight = (GameObject)Instantiate(Resources.Load("Rotating_Pointlight"));
                GameObject spotlight_child = spotlight.transform.GetChild(0).gameObject;
                spotlight_child.transform.Translate(new Vector3(tunnelParams.durchmesser / 2 - 0.5f, 0, 0));
                spotlight.transform.position = new Vector3(0, 0, Random.Range(distance, distance + section.laenge)); //randomize position
                spotlight.transform.Rotate(Vector3.forward, Random.Range(0, 360), Space.Self); //randomize orientation

                var script = spotlight.GetComponent<RotateSpotlight>();
                script.speed = section.drehgeschwindigkeit;


                float randomizedRed = Random.Range(section.minimumFarbe.r, section.maximumFarbe.r); //randomize color
                float randomizedGreen = Random.Range(section.minimumFarbe.g, section.maximumFarbe.g);
                float randomizedBlue = Random.Range(section.minimumFarbe.b, section.maximumFarbe.b);
                spotlight_child.GetComponent<Light>().color = new Color(randomizedRed, randomizedGreen, randomizedBlue);

                spotlight_child.GetComponent<Light>().intensity = 20;
                spotlight_child.GetComponent<Light>().range = 0.65f;
            }

            distance = distance + section.laenge;
            Debug.Log("Bisher " + distance + "zurückgelegt");
        }
        
        
        

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
