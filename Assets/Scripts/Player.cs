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
        if ( (other.gameObject.CompareTag("Bullet") && other.GetComponent<Bullet>().hostile ) 
            || other.gameObject.CompareTag("Enemy") ) 
        {
            selfEsteem--;
            // Hurt the player
            if(selfEsteem>=0)
            SelfEsteemBar.singleton.decrementSelfEsteemBar(selfEsteem);
            //if(selfEsteem==0)
            //lose condition
        }
    }
    public float bulletSpeed = 1;
    public Sprite bulletSprite;
    public float scale = 0.25f;

    public void Update () {
        if(Input.GetButton("Fire1")) {
			Vector2 direction = Vector2.up;
            
			var sp = BulletPool.rent();
			sp.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
			sp.GetComponent<Bullet>().Init(direction, 0, bulletSpeed, 0, bulletSprite, Color.white, false);
		    
        	sp.transform.localScale = Vector3.one * scale;
        }
    }
}
