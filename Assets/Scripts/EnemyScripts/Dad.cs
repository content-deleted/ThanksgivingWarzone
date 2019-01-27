using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dad : MonoBehaviour
{
    public float Frequency = 20;
    public float SideSpeed = 2;
    public float Speed = 20;
    public float SecondsTillFall;

    private bool _trigger;
    private GameObject _lerpPoint;

    void Start()
    {
        _lerpPoint = new GameObject();
        StartCoroutine(TriggerFall());
    }

    // Update is called once per frame
    void Update()
    {
        MoveDad();
    }
    bool dir=false;
    private void MoveDad()
    {  
        if (!_trigger) {
            transform.position += new Vector3(dir? SideSpeed : -SideSpeed,0,0); 
            if(transform.position.x > 5) dir = false;
            else if(transform.position.x < -5) dir = true;
            if(transform.position.y > 4.5f) transform.position -= new Vector3(0, 0.1f, 0);
  
        }
        else transform.position += _lerpPoint.transform.position / Speed;

        //transform.position = Vector3.MoveTowards(transform.position, _lerpPoint.transform.position, .05f);
    }

    IEnumerator TriggerFall()
    {
        yield return new WaitForSeconds(SecondsTillFall);
        _trigger = true;
        _lerpPoint.transform.position = Player.instance.transform.position - transform.position;
        GetComponent<LetterSpawn>().ENABLED = false;
    }
}
