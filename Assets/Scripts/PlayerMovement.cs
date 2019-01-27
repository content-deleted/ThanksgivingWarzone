using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 0.15f;
    Animator anim;
    int anime=0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x > 0&&anime!=1)
        {
            anim.SetTrigger("Right");
            anime = 1;
        }
        else if (x < 0 && anime != -1)
        {
            anim.SetTrigger("Left");
            anime = -1;
        }
        if (x == 0 && anime != 0)
        {
            anim.SetTrigger("Idle");
            anime = 0;
        }
        Vector3 move = moveSpeed * new Vector3(x, y,0);
        if( Mathf.Abs(transform.localPosition.x + move.x) > 5 )
        move.x = 0;
        if(Mathf.Abs(transform.localPosition.y + move.y) > 5 )
        move.y = 0;
        transform.localPosition += move;
    }
}
