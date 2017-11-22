using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildTunnel : MonoBehaviour {

    private LoadParamsFromXML tunnelParams = new LoadParamsFromXML();
 
	// Create the tunnel
	void Start () {
        tunnelParams.LoadParams(Application.dataPath + "//vortexparams.xml");

        //Switch to intro scene first, if specified in XML
        if (tunnelParams.intro)
        {
            SceneManager.LoadScene("Intro_Scene");
        }

        float distance = 0;
        float gangplankstart;

        foreach(Section section in tunnelParams.sections)
        {
            if (distance == 0)
            {
                gangplankstart = 3f;
            }
            else
            {
                gangplankstart = 0;
            }
            
            GameObject tunnel = (GameObject)Instantiate(Resources.Load("TunnelStraightScaled"));
            tunnel.transform.position = new Vector3(0, 0, distance);
            //Modify Tunnel Object according to params
            tunnel.transform.localScale = new Vector3(tunnelParams.durchmesser, tunnelParams.durchmesser, section.laenge);
            loadTexture(tunnel, Application.dataPath + "/" + section.texture);
            setTextureRotation(tunnel, 1, section.texturgeschwindigkeit);
            //Modify Gangplank according to params
            GameObject handrail = (GameObject)Instantiate(Resources.Load("handrail"));
            handrail.transform.position = new Vector3(0, -0.45f, distance - gangplankstart);
            handrail.transform.localScale = new Vector3(1, 1, section.laenge + gangplankstart);

            GameObject gangplank = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Material gangplankMaterial;
            Renderer gangplankRenderer = gangplank.GetComponent<Renderer>();
            gangplank.transform.localScale = new Vector3(1, 0.1f, section.laenge + gangplankstart);
            gangplank.transform.position += new Vector3(0, -1, distance + (section.laenge - gangplankstart) / 2);
            switch (section.steg.ToLower())
            {
                case "gitter":
                    gangplankMaterial = Resources.Load("Grid", typeof(Material)) as Material;
                    gangplankRenderer.material = gangplankMaterial;

                    break;

                case "glas":
                    gangplankMaterial = Resources.Load("Glass", typeof(Material)) as Material;
                    gangplankRenderer.material = gangplankMaterial;
                    break;
                default:
                    gangplankMaterial = Resources.Load("Grid", typeof(Material)) as Material;
                    gangplankRenderer.material = gangplankMaterial;
                    
                    break;
            }
            
            gangplankRenderer.material.mainTextureScale = new Vector2(1, section.laenge);
            
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

    public void setTextureRotation(GameObject gameObject, int direction, float speed)
    {
        TurnTexture turner = gameObject.GetComponentInChildren<TurnTexture>();
        turner.setDirection(1);
        turner.setSpeed(speed);
        gameObject.SetActive(true);
    }

    public void loadTexture(GameObject gameObject, string path)
    {

        //strip any file-extension that might be around
        string filename = System.IO.Path.GetFileNameWithoutExtension(path);
        Renderer renderer = gameObject.GetComponentInChildren<Renderer>();


        //Important Resources.Load DOES NOT work with file-extensions, it just wants the name like abc instead of abc.txt
        Texture2D texture = Resources.Load(filename) as Texture2D;
        renderer.material.color = Color.green;
        renderer.material.mainTexture = texture;
    }




    // Update is called once per frame
    void Update () {
		
	}
}
