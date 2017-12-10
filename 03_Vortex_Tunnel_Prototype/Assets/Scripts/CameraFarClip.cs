using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFarClip : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam = GetComponent<Camera>();
        cam.farClipPlane = cam.farClipPlane * 100;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
