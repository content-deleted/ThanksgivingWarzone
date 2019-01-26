using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    float moveSpeed = 0.25f;

    public int selfEsteem;

    //singleton
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }



    void FixedUpdate()
    {
        float X=Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");
        //if(X>0) StraiffRight();
        //if(X<0) StraiffLeft();
        Vector3 axis = new Vector3(X, Y,0);
        transform.localPosition += axis * moveSpeed;
    }
}
