using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnScreenEnemy : MonoBehaviour
{
    // This is the method to call after we awaken the enemy
    public event Action start;
    void Awake()
    {
        EnemyController.inactiveEnemies.Add(this);
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Call this when the enemy goes on screen
    /// </summary>
    public void Awaken () {
        gameObject.SetActive(true);
        start?.Invoke();
    }
}
