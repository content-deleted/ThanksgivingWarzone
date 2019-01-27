using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : MonoBehaviour
{
    public float Speed = 20;

    private GameObject _lerpPoint;

    private void Awake()
    {
        _lerpPoint = new GameObject();
        GetComponent<OnScreenEnemy>().start += GetPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if(_lerpPoint != null) MoveMom();
    }

    private void MoveMom()
    {
        transform.position += _lerpPoint.transform.position / Speed;
    }

    private void GetPosition()
    {
        _lerpPoint.transform.position = Player.instance.transform.position - transform.position;
    }
}
