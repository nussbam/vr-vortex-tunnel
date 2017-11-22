using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTexture : MonoBehaviour {

    Vector2 offset = Vector2.zero;
    private float speed;
    private int direction = 1;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);
        offset.x = direction * (offset.x + speed * Time.deltaTime);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTextureOffset = offset;


    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setDirection(int direction)
    {
        if (direction >= 0)
        {
            this.direction = 1;
        }
        else
        {
            this.direction = -1;
        }
    }
}
