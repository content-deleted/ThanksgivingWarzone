using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class AuntJenny : MonoBehaviour
{
    LetterSpawn letters;
    BulletSpawner bullets;
    EnemyHealth health;
    int phase=0;
    void Awake () {
        letters = GetComponent<LetterSpawn>();
        bullets = GetComponent<BulletSpawner>();
        health = GetComponent<EnemyHealth>();
    }
    void Start() {
        // set initial spawnner values

    }
    void Update()
    {
        switch(phase){
            case 0:
                if(transform.position.y > 2.25)
                    transform.position -= new Vector3(0,0.03f,0);
                if(health.health < 20) {
                    phase = 1;
                    firstAttack();
                }
                break;
            case 1:
                if(health.health<=1) SceneManager.LoadScene("WinScreen");
                break;
        }

    }

    void firstAttack() {
        List<string> Topics = new List<string>();
        Topics.Add("GO TO YOUR ROOM");
        Topics.Add("YOUVE HAD ENOUGH TO EAT");
        Topics.Add("AAAAAAAAAA");
        Topics.Add("YOU VOTED WRONG");
        Topics.Add("HATE HATE HATE");

        letters.Topics = Topics;
        letters.bulletAmount=8;
        letters.bulletSpeed=5;
        letters.bulletfrequency=0.3f;
        letters.spin=0.3f;
        letters.timeBetweenLetters = 2;

        letters.updateBulletAmount ();
    }
}
