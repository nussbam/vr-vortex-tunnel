using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTexture : MonoBehaviour {

    Vector2 offset = Vector2.zero;
    float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        offset.x = (offset.x + speed * Time.deltaTime);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTextureOffset = offset;

    }
}
