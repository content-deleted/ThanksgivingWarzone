using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 0.15f;
    Animator anim;
    int anime=0;
    public SelfEsteemBar spiral;
    public static PlayerMovement instance;
    private int SelfEsteem=4;
    public GameObject gameOverScreen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

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
        Vector3 axis = new Vector3(x, y,0);
        transform.localPosition += axis * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Tiggered");
        if (other.tag.Equals("Bad"))
        {
            spiral.decrementSelfEsteemBar();
            SelfEsteem--;
        }
        if (other.tag.Equals("VeryBad"))
        {
            spiral.decrementSelfEsteemBar();
            SelfEsteem--;
            if (SelfEsteem <= 0)
            {
                Destroy(gameObject);
                gameOverScreen.SetActive(true);
            }
            spiral.decrementSelfEsteemBar();
            SelfEsteem--;

        }
        if (SelfEsteem <= 0)
        {
            Destroy(gameObject);
            gameOverScreen.SetActive(true);
        }
        if (other.tag.Equals("Good"))
        {
            anim.SetTrigger("GotFood");
            other.attachedRigidbody.isKinematic = false;
            other.transform.position = new Vector3(-28+Random.value*2.5f,0, 0);
            //Heal
            if (SelfEsteem < 4)
            {
                spiral.incrementSelfEsteemBar();
            }
        }
    }
}
