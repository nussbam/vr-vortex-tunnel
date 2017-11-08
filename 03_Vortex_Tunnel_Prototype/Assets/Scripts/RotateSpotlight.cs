using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpotlight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
       transform.Rotate(Vector3.forward *150 * Time.deltaTime, Space.Self);
    }
}
