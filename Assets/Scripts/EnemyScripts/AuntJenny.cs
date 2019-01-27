using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuntJenny : MonoBehaviour
{
    LetterSpawn letters;
    BulletSpawner bullets;
    int phase=0;
    void Awake () {
        letters = GetComponent<LetterSpawn>();
        bullets = GetComponent<BulletSpawner>();
    }
    void Start() {
        // set initial spawnner values

    }
    void Update()
    {
        switch(phase){
            case 0:
                firstAttack();
                break;
            
        }
    }

    void firstAttack() {

    }
}
