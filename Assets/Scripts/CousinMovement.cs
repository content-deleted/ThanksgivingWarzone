using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CousinMovement : MonoBehaviour
{
    public float downSpeed;
    public float sideSpeed;
    public int sideTime;
     int timer=0;

    void Start()
    {
        downSpeed *= .01f;
        sideSpeed *= .01f;
        //start += Logger;
    }

    void Update()
    {
        timer++;
        float X;
        if(timer< sideTime)
        {
            X = sideSpeed;
        }
        else if (timer < 2* sideTime)
        {
            X = -sideSpeed;
        }
        else
        {
            X = sideSpeed;
            timer = 0;
        }
        transform.position += new Vector3(X,-downSpeed, 0);
    }
}
