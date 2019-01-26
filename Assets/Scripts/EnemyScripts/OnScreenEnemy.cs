using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenEnemy : MonoBehaviour
{
    static List<OnScreenEnemy> inactiveEnemies = new List<OnScreenEnemy>();
    void Awake()
    {
        inactiveEnemies.Add(this);
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Call this when the enemy goes on screen
    /// </summary>
    public void Awaken () {

    }
}
