using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int selfEsteem;

    //singleton
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    Animator anim;

        private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D other) {
        if ( (other.gameObject.CompareTag("Bullet") && other.GetComponent<Bullet>().hostile ) 
            || other.gameObject.CompareTag("Enemy") ) 
        {
            selfEsteem--;
            // Hurt the player
            if (selfEsteem > 0) SelfEsteemBar.singleton.decrementSelfEsteemBar(selfEsteem);
            else SceneManager.LoadScene("GameOver");
            //if(selfEsteem<=0)
                //gameOverScreen.SetActive(true);

            if(other.gameObject.CompareTag("Bullet")) other.GetComponent<Bullet>().BulletDestroy ();
        }
        else if (other.tag.Equals("Good"))
        {
            anim.SetTrigger("GotFood");
            other.attachedRigidbody.isKinematic = false;
            other.transform.position = new Vector3(-28+Random.value*2.2f,0, 0);
            //Heal
            if (selfEsteem < 4)
            {
                selfEsteem++;
                SelfEsteemBar.singleton.incrementSelfEsteemBar(selfEsteem-1);
                print(selfEsteem);
                //selfEsteem++;
            }
        }
    }
    public float bulletSpeed = 1;
    public Sprite bulletSprite;
    public float scale = 0.25f;
    public float shootFrameReset;

    private float timer = 0;

    public void Update () {
        if (Input.GetButton("Fire1") && timer < 0)
        {
            Vector2 direction = Vector2.up;

            var sp = BulletPool.rent();
            sp.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            sp.GetComponent<Bullet>().Init(direction, 0, bulletSpeed, 0, bulletSprite, Color.white, false);

            sp.transform.localScale = Vector3.one * scale;
            timer = shootFrameReset;
        }
        timer--;
    }
}
