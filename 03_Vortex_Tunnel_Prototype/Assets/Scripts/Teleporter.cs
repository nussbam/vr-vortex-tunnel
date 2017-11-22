using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered - Teleporting to Vortex Tunnel");
        SceneManager.LoadScene("MS3_Prototyp");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
