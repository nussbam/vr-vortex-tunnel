using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.green;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
