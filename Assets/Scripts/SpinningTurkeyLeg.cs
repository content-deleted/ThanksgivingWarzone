using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningTurkeyLeg : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.forward, Time.time);
    }
}
