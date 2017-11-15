using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpotlight : MonoBehaviour {

    public int speed;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
       transform.Rotate(Vector3.forward *speed * Time.deltaTime, Space.Self);
    }
}
