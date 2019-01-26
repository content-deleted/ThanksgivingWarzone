using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool moving = true;
    public bool shake = false;
    public float intensity = 1;
    public float speed = 0.5f;

    public float yLocation = 0;
    // Apply to the player as well
    

    private System.Random rand =  new System.Random();
    void Update()
    {
        if(moving) yLocation += speed;
    }

    void LateUpdate() {
        transform.position = new Vector3(0,yLocation,transform.position.z);
        if(shake) {
            transform.position += new Vector3(intensity*(float)rand.NextDouble(), intensity*(float)rand.NextDouble(), 0);
        }
    }
}
