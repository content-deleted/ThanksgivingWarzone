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

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            selfEsteem--;
            // Hurt the player
            if(selfEsteem>=0)
            SelfEsteemBar.singleton.decrementSelfEsteemBar(selfEsteem);
            //if(selfEsteem==0)
            //lose condition
        }
    }
}
