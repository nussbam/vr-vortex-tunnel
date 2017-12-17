using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildTunnel : MonoBehaviour {

    private LoadParamsFromXML tunnelParams = new LoadParamsFromXML();



    // Create the tunnel
    IEnumerator Start () {
        tunnelParams.LoadParams(Application.dataPath + "//vortexparams.xml");


        float tunnelStart;
        float distance = 0;
        foreach(Section section in tunnelParams.sections)
        {
            if (distance == 0)
            {
                tunnelStart = 3f;
            }
            else
            {
                tunnelStart = 0;
            }
            
            GameObject tunnel = (GameObject)Instantiate(Resources.Load("TunnelStraightScaled"));
            Renderer tunnelRenderer = tunnel.GetComponentInChildren<Renderer>();
            tunnel.transform.position = new Vector3(0, 0, distance);

            //Modify Tunnel Object according to params
            tunnel.transform.localScale = new Vector3(tunnelParams.durchmesser, tunnelParams.durchmesser, section.laenge);
            yield return loadTexture(tunnelRenderer, section.texture);
            setTextureRotation(tunnel, section.texturRichtung, section.texturgeschwindigkeit);

            //Modify Gangplank and Handrails according to params
            if (section.gelaender == "on")
            {
                GameObject leftHandrail = (GameObject)Instantiate(Resources.Load("single_handrail"));
                leftHandrail.transform.position = new Vector3(-section.stegBreite/2, section.stegHoehe + 0.7f, distance - tunnelStart);
                leftHandrail.transform.localScale = new Vector3(1, 1, section.laenge + tunnelStart);

                GameObject rightHandrail = (GameObject)Instantiate(Resources.Load("single_handrail"));
                rightHandrail.transform.position = new Vector3(section.stegBreite / 2, section.stegHoehe + 0.7f, distance - tunnelStart);
                rightHandrail.transform.localScale = new Vector3(1, 1, section.laenge + tunnelStart);
            }
            

            GameObject gangplank = (GameObject)Instantiate(Resources.Load("gangplank"));

            gangplank.transform.localScale = new Vector3(section.stegBreite, 0.0001f, section.laenge + tunnelStart);
            gangplank.transform.position += new Vector3(0, section.stegHoehe, distance + ( section.laenge - tunnelStart) / 2);

            //adjust height of camera to height of first gangplank
            if(distance == 0) { 
                GameObject vrCam = GameObject.Find("[CameraRig]");
                vrCam.transform.position = new Vector3(0, section.stegHoehe, 5);
            }

            Renderer gangplankRenderer = gangplank.GetComponent<Renderer>();
            yield return loadTexture(gangplankRenderer, section.stegTextur);
            gangplankRenderer.material.mainTextureScale = new Vector2(1, section.laenge);
            Color currentColor = gangplankRenderer.material.color;
            
            currentColor.a = section.stegTransparenz;
            gangplankRenderer.material.color = currentColor;


            //Create Spotlights along the tunnel
            generateLights(section, distance);

      
            distance = distance + section.laenge;

        }

        
    }

    public void generateLights(Section section, float distance)
    {
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

            spotlight_child.GetComponent<Light>().intensity = section.lichtIntensitaet;
            spotlight_child.GetComponent<Light>().range = section.lichtReichweite;
        }
    }

    public void setTextureRotation(GameObject gameObject, string direction, float speed)
    {
        int directionInt;
        if(direction.ToLower() == "rechts")
        {
            directionInt = -1;
        }else
        {
            directionInt = 1;
        }
        TurnTexture turner = gameObject.GetComponentInChildren<TurnTexture>();
        turner.setDirection(directionInt);
        turner.setSpeed(speed/10);
        gameObject.SetActive(true);
    }

    public IEnumerator loadTexture(Renderer renderer, string path)
    {

        if (!path.Contains("/") || !path.Contains("\\"))
        {
            //if there is just a filename it is in the application data
            path = Application.dataPath + "/" + path;
        }
        Debug.Log("Filepath for texture is" + path);
        WWW picture = new WWW("file://"+path);
        while (!picture.isDone)
            yield return null;
        
        renderer.material.mainTexture = picture.texture;

    }




    // Update is called once per frame
    void Update () {
		
	}
}
