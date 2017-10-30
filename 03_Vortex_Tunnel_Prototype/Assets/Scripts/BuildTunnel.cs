using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTunnel : MonoBehaviour {

    private LoadParamsFromXML tunnelParams = new LoadParamsFromXML();
 
	// Create the tunnel
	void Start () {
        //Create Tunnel Object from Prefab
        GameObject tunnel = (GameObject)Instantiate(Resources.Load("Tunnel_Straight"));
        tunnel.transform.position = new Vector3(0, 0, 0);

        //Modify Tunnel Object according to params
        tunnel.transform.localScale = new Vector3(tunnelParams.durchmesser, tunnelParams.durchmesser, tunnelParams.laenge);

        //Create Spotlights along the tunnel

        for (int i = 0; i < tunnelParams.punktdichte; i++)
        {
            
            GameObject spotlight = (GameObject)Instantiate(Resources.Load("Rotating_Spotlight"));
            spotlight.transform.position = new Vector3(0, 0, Random.Range(0, tunnelParams.laenge)); //randomize position
            spotlight.transform.Rotate(Vector3.right, Random.Range(0,360), Space.Self); //randomize orientation

            float randomizedRed = Random.Range(tunnelParams.minimumFarbe.r, tunnelParams.maximumFarbe.r); //randomize color
            float randomizedGreen = Random.Range(tunnelParams.minimumFarbe.g, tunnelParams.maximumFarbe.g);
            float randomizedBlue = Random.Range(tunnelParams.minimumFarbe.b, tunnelParams.maximumFarbe.b);
            spotlight.GetComponent<Light>().color = new Color(randomizedRed, randomizedGreen, randomizedBlue);

            spotlight.GetComponent<Light>().intensity = 20;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
