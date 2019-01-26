using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool shake = false;
    public float intensity = 1;

    private System.Random rand =  new System.Random();
    void LateUpdate() {
        transform.position = new Vector3(0,0,transform.position.z);
        if(shake) {
            transform.position += new Vector3(intensity*(float)rand.NextDouble(), intensity*(float)rand.NextDouble(), 0);
        }
    }
}
