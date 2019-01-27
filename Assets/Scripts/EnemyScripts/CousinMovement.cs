using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CousinMovement : MonoBehaviour
{
    public GameObject Chad;
    public GameObject Brad;
    public float Frequency = 20;
    public float Speed = 50;

    void Start()
    {
        //downSpeed *= .01f;
        //sideSpeed *= .01f;
        //start += Logger;
    }

    void Update()
    {
        MoveEnemies();
        /*
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
        */
    }

    private void MoveEnemies()
    {
        Chad.transform.position += new Vector3(Mathf.Sin(Time.time) / Frequency, -Time.time / Speed, 0);
        Brad.transform.position += new Vector3(-Mathf.Sin(Time.time) / Frequency, -Time.time / Speed, 0);
    }
}
