using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Bullet") && !other.GetComponent<Bullet>().hostile)
            || other.gameObject.CompareTag("Enemy"))
        {
            health--;
            // Hurt the player
            if (health <= 0)
                Destroy(gameObject);
            //if(selfEsteem<=0)
            //gameOverScreen.SetActive(true);
            //lose condition
        }
    }
}
