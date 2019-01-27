using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    float speed;
    void Start()
    {
         speed = EnemyController.singleton.levelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0,speed,0);
    }
}
