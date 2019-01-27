using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    public static EnemyController singleton;
    public static List<OnScreenEnemy> inactiveEnemies = new List<OnScreenEnemy>();
    public void Awake () => singleton = this;
    public float levelSpeed;
    public void Update () {
        foreach(OnScreenEnemy enemy in inactiveEnemies.ToList()){
            enemy.transform.position -= new Vector3(0,levelSpeed,0);
            if(Utils.IsOnScreen(enemy.gameObject)) {
                enemy.Awaken();
                inactiveEnemies.Remove(enemy);
            }
        }
    }
}
